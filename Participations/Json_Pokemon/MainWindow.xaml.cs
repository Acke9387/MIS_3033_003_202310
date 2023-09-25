using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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
        private Pokemon api = null;
        bool showFront = true;

        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://pokeapi.co/api/v2/pokemon?offset=00&limit=1300";

            using (var client = new HttpClient())
            {
                string pokemonJson = client.GetStringAsync(url).Result;

                PokemonApi api = JsonConvert.DeserializeObject<PokemonApi>(pokemonJson);

                //foreach (var pokemon in api.results)
                //{
                //    cboPokemen.Items.Add(pokemon);
                //}

                api.results.OrderBy(pokemon => pokemon.name).ToList().ForEach(pokemon =>
                {
                    cboPokemen.Items.Add(pokemon);
                });
            }

            

        }

        private void cboPokemen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            PokemonResult selected = (PokemonResult)cboPokemen.SelectedItem;

            if(selected == null) { return; }

            using (var client = new HttpClient())
            {
                string pokemonJson = client.GetStringAsync(selected.url).Result;

                api = JsonConvert.DeserializeObject<Pokemon>(pokemonJson);
                txtHeight.Text = api.height.ToString();
                txtName.Text = api.name;
                txtWeight.Text = api.weight.ToString();

                imgPoke.Source = new BitmapImage(new Uri(api.sprites.front));
                showFront = false;
            }

        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            if (showFront == true)
            {
                imgPoke.Source = new BitmapImage(new Uri(api.sprites.front));
                showFront = false;
            }
            else
            {
                if (api.sprites.back_default != null)
                {
                    imgPoke.Source = new BitmapImage(new Uri(api.sprites.back_default)); 
                }
                showFront = true;
            }
        }
    }
}
