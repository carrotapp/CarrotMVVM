using Carrot.Core.Helpers;
using Carrot.Core.Models.DTO;
using Carrot.Core.Services.LocationService;
using Carrot.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System.Diagnostics;

namespace Carrot.Core
{
    public class AppStart: MvxAppStart
    {
        ILocationService _locationService;
        IMvxNavigationService _navigationService;
        private MvxSubscriptionToken _token;
        private IMvxMessenger _messenger;
        private Location _userLocation = new Location(Settings.LocationSettings);

        public AppStart(IMvxApplication application, ILocationService locationService, IMvxNavigationService navigationService, IMvxMessenger messenger) : base(application)
        {
            _messenger = messenger;
            _locationService = locationService;
            _navigationService = navigationService;
        }

        protected override async void Startup(object hint = null)
        {
            var PreviousUserLocation = Settings.LocationSettings;
            _userLocation = new Location(PreviousUserLocation);
            Debug.Print(_userLocation.ToString());
            if (!_userLocation.ToString().Equals("0:0"))
            {
                await _navigationService.Navigate<MapViewModel, Location>(_userLocation);
            }
            else
            {
                Debug.Print("Hit the else!");
                _token = _messenger.Subscribe<LocationMessage>(OnLocationMessage);
            }
            
        }

        private async void OnLocationMessage(LocationMessage locationMessage)
        {
            Debug.Print("\n\nGot this bitch's location!");
            _userLocation = locationMessage.UserLocation;
            Settings.LocationSettings = _userLocation.ToString();
            await _navigationService.Navigate<MapViewModel, Location>(_userLocation);
        }
    }
}
