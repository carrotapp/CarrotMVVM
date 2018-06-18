using Carrot.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carrot.Core.Models.DTO
{
    public class Place
    {
        [JsonProperty("coords")]
        public string Coords { get; set; }

        //public Location Coords
        //{
        //    get => Coords; set => new Location("" + value);
        //}

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("colour")]
        public string Colour { get; set; }
    }
}