using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Json_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://pokeapi.co/api/v2/pokemon?offset=00&limit=1300";

            using (var client = new HttpClient())
            {
                string pokemonJson = client.GetStringAsync(url).Result;

                PokemonApi api = JsonConvert.DeserializeObject<PokemonApi>(pokemonJson);

                api.results.OrderBy(pokemon => pokemon.name).ToList().ForEach(pokemon =>
                {
                    cboPokemen.Items.Add(pokemon);
                });
            }

            

        }
    }
}
