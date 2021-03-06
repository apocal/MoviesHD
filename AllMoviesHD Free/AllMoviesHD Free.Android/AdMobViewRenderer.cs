﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Admob.Droid;
using MoviesHD.Models;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace Admob.Droid
{
    public class AdMobViewRenderer : ViewRenderer<AdMobView, AdView>
    {
        public AdMobViewRenderer(Context context) : base(context) { }

      
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && Control == null)
                SetNativeControl(CreateAdView());
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
            base.OnElementPropertyChanged(sender, e);
            //if (e.PropertyName == nameof(AdView.AdUnitId))
            //    Control.AdUnitId = Element.AdUnitId;
        }
        private AdView CreateAdView()
        {
            var adView = new AdView(Context)
            {
                AdUnitId = Element.AdUnitId
            };
            if(Element.AdUnitHeight==0||Element.AdUnitWidth==0)
            {
                adView.AdSize = AdSize.SmartBanner;
            }
            else
            {
                adView.AdSize = new AdSize(Element.AdUnitWidth, Element.AdUnitHeight);
            }
            adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
         
            adView.LoadAd(new AdRequest.Builder().Build());

            return adView;
        }
    }
}