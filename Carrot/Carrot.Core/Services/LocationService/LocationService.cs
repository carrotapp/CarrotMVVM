using System;
using System.Diagnostics;
using Carrot.Core.Models.DTO;
using Carrot.Core.ViewModels;
using MongoDB.Driver;
using MvvmCross.Plugin.Location;
using MvvmCross.Plugin.Messenger;
using Carrot.Core.Helpers;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Carrot.Core.Models.Responses;
using Newtonsoft.Json.Linq;

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
            Location userLocation = new Location(location.Coordinates.Latitude, location.Coordinates.Longitude);
            var message = new LocationMessage(this, userLocation);
            _messenger.Publish(message);
        }

        public async Task PushUserLocationToDB(Location location)
        {
            var client = new MongoClient($"mongodb+srv://{Config.Username}:{Config.Password}@carrottestcluster-vakwr.mongodb.net/test?retryWrites=true");
            var database = client.GetDatabase("CarrotTestCluster");
            var doc = new BsonDocument
            {
                {"userLocation", location.ToString()}
            };
            await database.GetCollection<BsonDocument>("test").InsertOneAsync(doc);
            var count = await database.GetCollection<BsonDocument>("test").CountAsync(new BsonDocument());
            Debug.Print("Count: " + count);
        }

        public List<Place> GetMock()
        {
            var response = new PlaceResponse
            {
                Places = new List<Place>()
            };

            List<Place> places = new List<Place>();
            var assembly = typeof(App).Assembly;
            string[] streams = assembly.GetManifestResourceNames();

            foreach (string file in streams)
            {
                if (file.EndsWith("MockLocations.json"))
                {
                    Stream stream = assembly.GetManifestResourceStream(file);
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        response = (PlaceResponse)JsonConvert.DeserializeObject(streamReader.ReadToEnd(), typeof(PlaceResponse));
                    }
                    break;
                }
            }
            places = response.Places;

            return places;
        }
    }
}