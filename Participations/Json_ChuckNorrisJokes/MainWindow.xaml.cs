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

namespace Json_ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cboCategories.Items.Add("All");
            cboCategories.SelectedIndex = 0;

            using (var client = new HttpClient())
            {

                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;

                string[] categories = JsonConvert.DeserializeObject<string[]>(json);

                foreach (string category in categories)
                {
                    cboCategories.Items.Add(category);
                }
            }

        }

        private void btnGetJoke_Click(object sender, RoutedEventArgs e)
        {
            string category = cboCategories.SelectedItem.ToString();
            string url = @"https://api.chucknorris.io/jokes/random";

            if (category != "All")
            {
                url = $"https://api.chucknorris.io/jokes/random?category={category}";
            }

            using (var client = new HttpClient())
            {

                string json = client.GetStringAsync(url).Result;

                var joke = JsonConvert.DeserializeObject<ChuckNorrisJokeAPI>(json);
                txtJoke.Text = joke.value;
                
            }

        }
    }
}
