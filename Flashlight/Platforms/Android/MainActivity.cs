using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Flashlight.Pages;

namespace Flashlight;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
	ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
	                       ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
	[Register("onKeyDown", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyDown_ILandroid_view_KeyEvent_Handler")]
	public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
	{
		if (keyCode != Keycode.Power) return false;
		FlashlightController.PowerButtonPressed = true;
		return base.OnKeyDown(keyCode, e);
	}
	
	[Register("onKeyUp", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyUp_ILandroid_view_KeyEvent_Handler")]
	public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
	{
		if (keyCode != Keycode.Power) return false;
		FlashlightController.PowerButtonPressed = false;
		return base.OnKeyUp(keyCode, e);
	}
}