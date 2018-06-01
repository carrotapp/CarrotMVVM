using MvvmCross.ViewModels;
using MvvmCross.Plugin.Messenger;
using Carrot.Core.Models.DTO;
using Carrot.Core.Services.LocationService;
using System.Diagnostics;
using Carrot.Core.Helpers;
using System.Threading.Tasks;

namespace Carrot.Core.ViewModels
{
    public class MapViewModel : MvxViewModel
    {
        private readonly MvxSubscriptionToken _token;
        private readonly ILocationService _locationService;

        private double _lng;
        public double Lng {
            get => _lng;
            set => SetProperty(ref _lng, value);
        }

        private double _lat;
        public double Lat {
            get => _lat;
            set => SetProperty(ref _lat, value);
        }

        private Location _userLocation;
        public Location UserLocation {
            get => _userLocation;
            set => SetProperty(ref _userLocation, value);
        }

        public MapViewModel(ILocationService locationService, IMvxMessenger messenger)
        {
            _locationService = locationService;
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
            var PreviousUserLocation = Settings.LocationSettings;
            UserLocation = new Location(PreviousUserLocation);
        }

        private void OnLocationMessage(LocationMessage locationMessage)
        {
            UserLocation = locationMessage.UserLocation;
            Settings.LocationSettings = UserLocation.ToString();
        }

        public async Task TestDB()
        {
            Debug.Print("Starting Mongo thing!!!");
            await _locationService.PushUserLocationToDB(UserLocation);
        }
    }
}
