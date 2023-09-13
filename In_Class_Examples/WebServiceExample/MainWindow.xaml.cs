using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
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

namespace WebServiceExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //HttpClient client = new HttpClient();
            //client.Dispose();
            string json;
            using (var client = new HttpClient())
            {
                json = client.GetStringAsync("https://rickandmortyapi.com/api/character").Result;
            }

            RickAndMortyAPI api = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

            foreach (Result character in api.results)
            {
                cboCharacters.Items.Add(character);
            }
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var character = (Result)cboCharacters.SelectedItem;

            img.Source = new BitmapImage(new Uri(character.image));
        }
    }
}
