using System;
using Carrot.Core.Services.LocationService;
using Carrot.Core.ViewModels;
using MvvmCross;
using MvvmCross.Plugin.Location;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Carrot.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Mvx.RegisterSingleton<ILocationService>(() => new LocationService(IMvxLocationWatcher, IMvxMessenger));
            //Mvx.LazyConstructAndRegisterSingleton<ILocationService>(() => LocationService.Instance);

            //Mvx.RegisterSingleton<ILocationService>(() => new LocationService(watcher, message));
            Mvx.LazyConstructAndRegisterSingleton<ILocationService, LocationService>();
            RegisterAppStart<MapViewModel>();
        }
    }
}
