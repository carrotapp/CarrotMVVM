using System.Threading.Tasks;
using Android;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Gms.Location;
using Android.Locations;
using Android.Support.V4.Content;
using Android.Util;
using Android.Widget;
using Carrot.Core.ViewModels;
using Carrot.Droid.Views;

namespace Carrot.Droid.Services
{
    public class UserLocationService: IUserLocationService
    {
        private bool isRequestingLocationUpdates;
        private NetworkView _networkView;
        private FusedLocationProviderClient _fusedLocationProviderClient;
        private MapViewModel _mapViewModel;

        bool IsGooglePlayServicesInstalled()
        {
            var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(_networkView);
            if (queryResult == ConnectionResult.Success)
            {
                Log.Info("MainActivity", "Google Play Services is installed on this device.");
                return true;
            }

            if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
            {
                // Check if there is a way the user can resolve the issue
                var errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                Log.Error("MainActivity", "There is a problem with Google Play Services on this device: {0} - {1}",
                          queryResult, errorString);

                // Alternately, display the error to the user.
            }

            return false;
        }

        public UserLocationService(NetworkView networkView, MapViewModel mapViewModel)
        {
            _networkView = networkView;
            _mapViewModel = mapViewModel;
            if (ContextCompat.CheckSelfPermission(_networkView, Manifest.Permission.AccessFineLocation) == Permission.Granted)
            {
                StartRequestingLocationUpdates();
                isRequestingLocationUpdates = true;
            }
            else
            {
                Toast.MakeText(_networkView, "YOU! Have not enabled location access!", ToastLength.Short).Show();
                isRequestingLocationUpdates = false;
            }
        }

        private async void StartRequestingLocationUpdates()
        {
            _fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(_networkView);
            LocationRequest locationRequest = new LocationRequest()
                                  .SetPriority(LocationRequest.PriorityHighAccuracy)
                                  .SetInterval(60 * 1000 * 5)
                                  .SetFastestInterval(60 * 1000 * 2);
            UserLocationCallback locationCallback = new UserLocationCallback(_networkView, _mapViewModel);
            await _fusedLocationProviderClient.RequestLocationUpdatesAsync(locationRequest, locationCallback);
        }

        async Task GetLastLocationFromDevice()
        {
            // This method assumes that the necessary run-time permission checks have succeeded.
            Android.Locations.Location location = await _fusedLocationProviderClient.GetLastLocationAsync();

            if (location == null)
            {
                // Seldom happens, but should code that handles this scenario
            }
            else
            {
                // Do something with the location
                Log.Debug("Sample", "The latitude is " + location.Latitude);
            }
        }
    }
}