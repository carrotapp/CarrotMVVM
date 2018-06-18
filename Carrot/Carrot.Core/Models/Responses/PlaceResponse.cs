using Carrot.Core.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carrot.Core.Models.Responses
{
    public class PlaceResponse
    {
        [JsonProperty("locations")]
        public List<Place> Places { get; set; }
    }
}