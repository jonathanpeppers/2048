using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

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
    }
}

