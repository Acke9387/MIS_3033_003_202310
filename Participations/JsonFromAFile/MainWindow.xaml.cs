using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace JsonFromAFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<CarOwner> owners = new List<CarOwner>();

        public MainWindow()
        {
            InitializeComponent();

            string entireContentsOfJSONFile = File.ReadAllText("Mock_Data_Car_Owners.json");

            owners = JsonConvert.DeserializeObject<List<CarOwner>>(entireContentsOfJSONFile);

            foreach (CarOwner owner in owners)
            {
                if (cboColors.Items.Contains(owner.Color) == false)
                {
                    cboColors.Items.Add(owner.Color);
                }

                lstCars.Items.Add(owner);
            }

        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedColor = (string)cboColors.SelectedItem;
            lstCars.Items.Clear();
            foreach (var owner in owners)
            {
                if (owner.Color == selectedColor)
                {
                    lstCars.Items.Add(owner);
                }
            }

        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            string filteredContentAsJson = JsonConvert.SerializeObject(lstCars.Items, Formatting.Indented);

            string fileName = $"{cboColors.SelectedItem.ToString()}_Cars.json";

            File.WriteAllText(fileName, filteredContentAsJson);
            MessageBox.Show($"Successfully contents to {fileName}!");
        }
    }
}
