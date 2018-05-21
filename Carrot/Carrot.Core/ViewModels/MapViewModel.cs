using MvvmCross.ViewModels;
using MvvmCross.Plugin.Messenger;
using Carrot.Core.Models.DTO;
using Carrot.Core.Services.LocationService;
using System.Diagnostics;

namespace Carrot.Core.ViewModels
{
    public class MapViewModel : MvxViewModel
    {
        private readonly MvxSubscriptionToken _token;

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
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
        }

        private void OnLocationMessage(LocationMessage locationMessage)
        {
            Lat = locationMessage.Latitude;
            Lng = locationMessage.Longitude;
            UserLocation = new Location(Lat, Lng);
        }
    }
}
