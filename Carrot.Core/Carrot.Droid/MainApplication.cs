using System;
using Android.App;
using Android.Runtime;
using Carrot.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace Carrot.Droid {

    [Application]
    class MainApplication : MvxAndroidApplication<MvxAndroidSetup<App>, App> {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) {
        }
    }
}