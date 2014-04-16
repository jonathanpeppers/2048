using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace ChartboostSDK
{
	[BaseType (typeof (NSObject))]
	public partial interface Chartboost 
	{
		[Export ("appId", ArgumentSemantic.Retain)]
		string AppId { get; set; }

		[Export ("appSignature", ArgumentSemantic.Retain)]
		string AppSignature { get; set; }

		[Export ("rootView", ArgumentSemantic.Retain)]
		UIView RootView { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		ChartboostDelegate Delegate { get; set; }

		[Export ("timeout")]
		uint Timeout { get; set; }

		[Export ("orientation")]
		UIInterfaceOrientation Orientation { get; set; }

		[Static, Export ("sharedChartboost")]
		Chartboost SharedChartboost { get; }

		[Export ("startSession")]
		void StartSession ();

		[Export ("cacheInterstitial")]
		void CacheInterstitial ();

		[Export ("cacheInterstitial:")]
		void CacheInterstitial (string location);

		[Export ("showInterstitial")]
		void ShowInterstitial ();

		[Export ("showInterstitial:")]
		void ShowInterstitial (string location);

		[Export ("hasCachedInterstitial")]
		bool HasCachedInterstitial();

		[Export ("hasCachedInterstitial:")]
		bool HasCachedInterstitial (string location);

		[Export ("cacheMoreApps")]
		void CacheMoreApps ();

		[Export ("showMoreApps")]
		void ShowMoreApps ();

		[Export ("hasCachedMoreApps")]
		bool HasCachedMoreApps { get; }

		[Export ("dismissChartboostView")]
		void DismissChartboostView ();
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface ChartboostDelegate 
	{
		[Export ("shouldRequestInterstitial:")]
		bool ShouldRequestInterstitial (string location);

		[Export ("shouldDisplayInterstitial:")]
		bool ShouldDisplayInterstitial (string location);

		[Export ("didCacheInterstitial:")]
		void DidCacheInterstitial (string location);

		[Export ("didFailToLoadInterstitial:")]
		void DidFailToLoadInterstitial (string location);

		[Export ("didDismissInterstitial:")]
		void DidDismissInterstitial (string location);

		[Export ("didCloseInterstitial:")]
		void DidCloseInterstitial (string location);

		[Export ("didClickInterstitial:")]
		void DidClickInterstitial (string location);

		[Export ("shouldDisplayLoadingViewForMoreApps")]
		bool ShouldDisplayLoadingViewForMoreApps { get; }

		[Export ("shouldDisplayMoreApps")]
		bool ShouldDisplayMoreApps { get; }

		[Export ("didCacheMoreApps")]
		void DidCacheMoreApps ();

		[Export ("didFailToLoadMoreApps")]
		void DidFailToLoadMoreApps ();

		[Export ("didDismissMoreApps")]
		void DidDismissMoreApps ();

		[Export ("didCloseMoreApps")]
		void DidCloseMoreApps ();

		[Export ("didClickMoreApps")]
		void DidClickMoreApps ();

		[Export ("shouldRequestInterstitialsInFirstSession")]
		bool ShouldRequestInterstitialsInFirstSession { get; }
	}
}