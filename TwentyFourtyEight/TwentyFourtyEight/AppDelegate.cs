using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ChartboostSDK;

namespace TwentyFourtyEight
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            //Uncomment to see font names
//            string fonts = "";
//            var fontFamilies = new List<string>(UIFont.FamilyNames);
//            fontFamilies.Sort();
//            foreach (String familyName in fontFamilies)
//            {
//                foreach (String fontName in UIFont.FontNamesForFamilyName (familyName))
//                {
//                    fonts += fontName + "\n";
//                }
//                fonts += "\n";
//            }
//            Console.WriteLine(fonts);   

            return true;
        }

        public override void OnActivated(UIApplication application)
        {
            var cb = Chartboost.SharedChartboost;
            #if _8402
            cb.AppId = "534ded021873da2d91f6f980";
            cb.AppSignature = "3691d7916a737613b37f6c7d6f4fb6987e2874b8";
            #else
            cb.AppId = "534ded211873da2d91f6f984";
            cb.AppSignature = "848822be26f3ccd2225c11ff41f9b03b73fbf320";
            #endif
            cb.Delegate = new AdDelegate();
            cb.StartSession();
            cb.CacheInterstitial();
        }

        private class AdDelegate : ChartboostDelegate
        {
            public override void DidCacheInterstitial(string location)
            {
                Console.WriteLine("Cached Chartboost!");
            }

            public override void DidFailToLoadInterstitial(string location)
            {
                Console.WriteLine("Failed to load Chartboost!");
            }

            public override bool ShouldDisplayInterstitial(string location)
            {
                return true;
            }

            public override bool ShouldRequestInterstitial(string location)
            {
                return true;
            }

            public override void DidDismissInterstitial(string location)
            {
                Chartboost.SharedChartboost.CacheInterstitial(location);
            }

            public override bool ShouldRequestInterstitialsInFirstSession
            {
                get { return false; }
            }
        }
    }
}

