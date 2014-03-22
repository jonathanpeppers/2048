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

            var font = UIFont.FromName("ClearSans-Bold", 60);
            _2.Font =
                _0.Font =
                _4.Font =
                _8.Font = font;

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

            #if FLAPPY
            var image = UIImage.FromFile("flappy.png");
            var imageView = new UIImageView(new RectangleF((View.Frame.Width - 100) / 2, (View.Frame.Height - 72) / 2, 100, 72))
            {
                Image = image,
            };
            _splash.AddSubview(imageView);
            _splash.SendSubviewToBack(imageView);

            UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseInOut, () => imageView.Alpha = 0, null);
            #endif
        }

        public async override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var url = NSUrl.FromFilename("Html/index.html");
            var request = new NSUrlRequest(url);

            _webView.LoadRequest(request);

            //Start out 0 and 8 from bottom
            {
                var frame = _0.Frame;
                frame.Y = View.Frame.Height;
                _0.Frame = frame;

                frame = _8.Frame;
                frame.Y = View.Frame.Height;
                _8.Frame = frame;
            }

            UIView.SetAnimationCurve(UIViewAnimationCurve.EaseInOut);

            await UIView.AnimateAsync(.5, () =>
            {
                var frame = _2.Frame;
                frame.Y = (View.Frame.Height - _2.Frame.Height) / 2;
                _2.Frame = frame;

                frame = _0.Frame;
                frame.Y = (View.Frame.Height - _0.Frame.Height) / 2;
                _0.Frame = frame;

                frame = _4.Frame;
                frame.Y = (View.Frame.Height - _4.Frame.Height) / 2;
                _4.Frame = frame;

                frame = _8.Frame;
                frame.Y = (View.Frame.Height - _8.Frame.Height) / 2;
                _8.Frame = frame;
            });

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

        private async void HideSplash()
        {
            if (_loaded && _animated)
            {
                await Task.Delay(1000);

                UIView.Animate(.3, 0, UIViewAnimationOptions.CurveEaseInOut, () => _splash.Alpha = 0, _splash.RemoveFromSuperview);
            }
        }
    }
}
