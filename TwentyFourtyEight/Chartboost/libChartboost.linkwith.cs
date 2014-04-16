using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libChartboost.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true,
	Frameworks = "QuartzCore SystemConfiguration CoreGraphics", WeakFrameworks = "StoreKit AdSupport")]
