using System;
using System.Diagnostics;
using Carrot.Core.Models.DTO;
using MvvmCross.Plugin.Location;
using MvvmCross.Plugin.Messenger;

namespace Carrot.Core.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly IMvxLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;

        public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            _watcher = watcher;
            _messenger = messenger;
            MvxLocationOptions options = new MvxLocationOptions
            {
                TimeBetweenUpdates = TimeSpan.FromSeconds(20)
            };
            watcher.Start(options, OnLocation, OnError);
        }

        public void OnError(MvxLocationError error)
        {
            Debug.Print("Error: " + error.Code);
        }

        public void OnLocation(MvxGeoLocation location)
        {
            var message = new LocationMessage(this, location.Coordinates.Latitude, location.Coordinates.Longitude);
            _messenger.Publish(message);
        }
    }
}
