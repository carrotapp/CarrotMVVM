using Carrot.Core.Services.LocationService;
using Carrot.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace Carrot.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<ILocationService, LocationService>();
            //Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            //RegisterCustomAppStart<AppStart>();
            RegisterAppStart<LoadingViewModel>();
        }
    }
}
