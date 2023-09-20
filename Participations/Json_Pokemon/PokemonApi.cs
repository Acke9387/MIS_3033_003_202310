
using System.Collections.Generic;

namespace Json_Pokemon
{
    public class PokemonApi
    {

        public List<PokemonResult> results { get; set; }

    }

    public class PokemonResult
    {
        public string name { get; set; }

        public string url { get; set; }

        public override string ToString()
        {
            return name;
        }

    }
}