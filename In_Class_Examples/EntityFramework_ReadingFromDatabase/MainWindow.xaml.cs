using EntityFramework_ReadingFromDatabase.Models;
using System;
using System.Collections.Generic;
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

namespace EntityFramework_ReadingFromDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DB_128040_practiceContext db = new DB_128040_practiceContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCollectData_Click(object sender, RoutedEventArgs e)
        {
            foreach (FootballSchedule item in db.FootballSchedules)
            {
                if (item.IsHomeGame == true)
                {
                    lstHome.Items.Add(item); 
                }
                else
                {
                    lstAway.Items.Add(item);
                }
            }
        }
    }
}
