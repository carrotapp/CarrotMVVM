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

        private void ReadJsonFile()
        {
            using (StreamReader r = new StreamReader("JSON/MockLocations.json"))
            {
                string values = r.ReadToEnd();
                Console.WriteLine("VALUES: "+values);
                List<LocationList> places = JsonConvert.DeserializeObject<List<LocationList>>(values);
                Console.WriteLine("PLACES"+places);
            }
            
           
                //dynamic array = JsonConvert.DeserializeObject(json);
        }
    


    }
}


