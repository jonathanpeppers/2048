using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TwentyFourtyEight
{
    public partial class MainController : UIViewController
    {
        public MainController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _ad.Alpha = 0;
            _webView.ScrollView.ScrollEnabled =
                _webView.ScrollView.Bounces = false;
            _webView.LoadError += (sender, e) =>
            {
                Console.WriteLine("LoadError: " + e.Error.LocalizedDescription);
            };
            _ad.AdLoaded += (sender, e) =>
            {
                Console.WriteLine("Ad loaded!");

                UIView.Animate(0.3, 0, UIViewAnimationOptions.CurveEaseInOut, () => _ad.Alpha = 1, null);
            };
            _ad.FailedToReceiveAd += (sender, e) =>
            {
                Console.WriteLine("Ad failed: " + e.Error.LocalizedDescription);

                _ad.Alpha = 0;
            };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var url = NSUrl.FromFilename("Html/index.html");
            var request = new NSUrlRequest(url);

            _webView.LoadRequest(request);
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }

        public override bool ShouldAutorotate()
        {
            return false;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}
