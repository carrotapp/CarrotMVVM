using Carrot.Core.Helpers;
using Carrot.Core.Models.DTO;
using Carrot.Core.Services.LocationService;
using Carrot.Core.ViewModels;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System;
using System.Diagnostics;

namespace Carrot.Core
{
    public class AppStart : MvxAppStart
    {
        ILocationService _locationService;
        IMvxNavigationService _navigationService;
        private readonly MvxSubscriptionToken _token;
        private Location _userLocation = new Location(Settings.LocationSettings);

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, IMvxMessenger messenger) : base(application)
        {
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            _navigationService = navigationService;
        }

        protected override async void Startup(object hint = null)
        {
            var PreviousUserLocation = Settings.LocationSettings;
            _userLocation = new Location(PreviousUserLocation);
            Debug.WriteLine(_userLocation.ToString());
            if (_userLocation.ToString().Equals("0:0"))
            {
                await _navigationService.Navigate<MapViewModel, Location>(_userLocation);
            }
            else
            {
                try
                {
                    _locationService = Mvx.Resolve<LocationService>();

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        private async void OnLocationMessage(LocationMessage locationMessage)
        {
            Debug.WriteLine("\n\nGot the location!");
            _userLocation = locationMessage.UserLocation;
            Settings.LocationSettings = _userLocation.ToString();
            await _navigationService.Navigate<MapViewModel, Location>(_userLocation);
        }
    }
}
