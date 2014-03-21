// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace TwentyFourtyEight
{
	[Register ("MainController")]
	partial class MainController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel _0 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _4 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel _8 { get; set; }

		[Outlet]
		MonoTouch.iAd.ADBannerView _ad { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView _splash { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIWebView _webView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_ad != null) {
				_ad.Dispose ();
				_ad = null;
			}

			if (_splash != null) {
				_splash.Dispose ();
				_splash = null;
			}

			if (_webView != null) {
				_webView.Dispose ();
				_webView = null;
			}

			if (_2 != null) {
				_2.Dispose ();
				_2 = null;
			}

			if (_0 != null) {
				_0.Dispose ();
				_0 = null;
			}

			if (_4 != null) {
				_4.Dispose ();
				_4 = null;
			}

			if (_8 != null) {
				_8.Dispose ();
				_8 = null;
			}
		}
	}
}
