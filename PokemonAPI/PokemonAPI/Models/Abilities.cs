using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PokemonAPI.Models
{
    public class Abilities
    {
        [JsonProperty("slot")]
        public string Slot { get; set; }

        [JsonProperty("is_hidden")]
        public string Is_hidden { get; set; }

        [JsonProperty("ability")]
        public Ability Ability { get; set; }
    }
}
