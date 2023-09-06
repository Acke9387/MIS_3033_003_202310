﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace JsonExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string json = File.ReadAllText("MOCK_DATA.json");

            

            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);

            foreach (Person person in people)
            {
                lstPeople.Items.Add(person);
            }
        }

        private void lstPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person selected = (Person)lstPeople.SelectedItem;

            MessageBox.Show($"{selected.email}");
        }
    }
}
