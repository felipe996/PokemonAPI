using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        [JsonProperty("results")]
        public List<Results> Results { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }


    }


}
