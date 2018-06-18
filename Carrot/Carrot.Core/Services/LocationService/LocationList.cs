using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Carrot.Core.Services.LocationService
{
    public class LocationList
    {
        //public string location { get; set; }
        public string coords { get; set; }
        public string name { get; set; }
        public string colour { get; set; }


        public List<LocationList> GetMock()
        {

            var response = new PlaceResponse
            {
                Places = new List<LocationList>()
            };

            List<LocationList> places = new List<LocationList>();
            var assembly = typeof(App).Assembly;
            string[] streams = assembly.GetManifestResourceNames();

            foreach (string file in streams)
            {
                Console.WriteLine("FILE " + file);
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
            Console.WriteLine(response.Places.Count);
            return places;
        }
        //private void ReadJsonFile()
        //{
        //    using (StreamReader reader = new StreamReader("JSON/MockLocations.json"))
        //    {
        //        string values = reader.ReadToEnd();
        //        Console.WriteLine("VALUES: " + values);
        //        List<LocationList> places = JsonConvert.DeserializeObject<List<LocationList>>(values);
        //        // var json = JsonConvert.DeserializeObject<Places<LocationList>>(StreamReader.ReadToEnd());
        //        Console.WriteLine("PLACES" + places);
        //        return;
        //    }
        //    //dynamic array = JsonConvert.DeserializeObject(json);
        //}
    }

    internal class PlaceResponse
    {
        public List<LocationList> Places { get; set; }
    }
}


