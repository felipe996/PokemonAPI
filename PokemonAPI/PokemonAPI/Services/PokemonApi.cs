using PokemonAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Services
{
    public class PokemonApi
    {
        readonly string _api_base_url = "http://pokeapi.co/api/v2";

     
        public async Task<List<Abilities>> GetPokemon(string url)
        {
            using (var client = new HttpClient())
            {
                //grab json from server
                var json = await client.GetStringAsync($"{url}");

                //Deserialize json
                var abilities = JsonConvert.DeserializeObject<RootObjets>(json);

                //return the items
                return abilities.abilities;
            }
        }
        public async Task<Pokemon> GetAllPokemon()
        {
            using (var client = new HttpClient())
            {
                //grab json from server
                var json = await client.GetStringAsync($"{_api_base_url}/pokemon");

                //Deserialize json
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);

                //return the items
                return pokemon;
            }
        }
    }
}
