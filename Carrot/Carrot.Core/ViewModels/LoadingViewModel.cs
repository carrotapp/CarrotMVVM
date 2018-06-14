using Carrot.Core.Models.DTO;
using Carrot.Core.Services.LocationService;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Carrot.Core.ViewModels
{
    public class LoadingViewModel: MvxViewModel
    {
        ILocationService _locationService;
        IMvxNavigationService _navigationService;
        MvxSubscriptionToken _token;
        
        public LoadingViewModel(ILocationService locationService, IMvxMessenger messenger, IMvxNavigationService navigationService)
        {
            _locationService = locationService;
            _navigationService = navigationService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
        }

        private async void OnLocationMessage(LocationMessage locationMessage)
        {
            await _navigationService.Navigate<MapViewModel, Location>(locationMessage.UserLocation);
        }
    }
}
