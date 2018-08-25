using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PokemonAPI.Models
{
   public class Ability
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
