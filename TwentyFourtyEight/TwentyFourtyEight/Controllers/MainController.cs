using System;
using System.Drawing;
using System.Threading.Tasks;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TwentyFourtyEight
{
    public partial class MainController : UIViewController
    {
        private bool _loaded = false;
        private bool _animated = false;

        public MainController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _ad.Alpha = 0;
            _webView.ScrollView.ScrollEnabled =
                _webView.ScrollView.Bounces = false;
            _webView.ShouldStartLoad = (webView, request, type) =>
            {
                if (!_loaded)
                {
                    _loaded = true;
                    return true;
                }

                return false;
            };
            _webView.LoadError += (sender, e) =>
            {
                Console.WriteLine("LoadError: " + e.Error.LocalizedDescription);
            };
            _webView.LoadFinished += (sender, e) =>
            {
                Console.WriteLine("LoadFinished: " + _webView.Request.Url.AbsoluteString);

                HideSplash();
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

        public async override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var url = NSUrl.FromFilename("Html/index.html");
            var request = new NSUrlRequest(url);

            _webView.LoadRequest(request);

            UIView.SetAnimationCurve(UIViewAnimationCurve.EaseInOut);

            await UIView.AnimateAsync(.5, () =>
            {
                var frame = _numbers.Frame;
                frame.Y = (View.Frame.Height - _numbers.Frame.Height) / 2;
                _numbers.Frame = frame;
            });

            await Task.Delay(500);

            _animated = true;
            HideSplash();
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

        private void HideSplash()
        {
            if (_loaded && _animated)
            {
                UIView.Animate(.3, 0, UIViewAnimationOptions.CurveEaseInOut, () => _splash.Alpha = 0, _splash.RemoveFromSuperview);
            }
        }
    }
}
