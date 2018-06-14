using Android.App;
using Android.OS;
using Carrot.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Carrot.Droid.Views
{
    [Activity(MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class LoadingScreenView : MvxActivity<LoadingViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);
        }
    }
}