using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Carrot.Core.ViewModels;
using Carrot.Droid.Views;

namespace Carrot.Droid.Services
{
    public class UserLocationCallback : LocationCallback
    {
        readonly NetworkView _networkView;
        readonly MapViewModel _mapViewModel;

        public UserLocationCallback(NetworkView networkView, MapViewModel mapViewModel)
        {
            _networkView = networkView;
            _mapViewModel = mapViewModel;
        }

        public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("FusedLocationProviderSample", "IsLocationAvailable: {0}", locationAvailability.IsLocationAvailable);
        }

        public override void OnLocationResult(LocationResult result)
        {
            if (result.Locations.Any())
            {
                var location = result.Locations.First();
                //_networkView._userLocation.Position = new LatLng(location.Latitude, location.Longitude);
                _mapViewModel.UserLocation = new Location(location.Latitude, location.Longitude);
            }
            else
            {
                Log.Debug("Location Error", "Could not get location");
            }
        }
    }
}