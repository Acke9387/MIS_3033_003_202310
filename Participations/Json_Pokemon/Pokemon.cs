using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Pokemon
{
    public class Pokemon
    {
        public int height { get; set; }

        public string name { get; set; }

        public Sprite sprites { get; set; }

        public int weight { get; set; }

    }

    public class Sprite
    {

        [JsonProperty("front_default")]
        public string front { get; set; }

        public string back_default { get; set;}

    }
}
