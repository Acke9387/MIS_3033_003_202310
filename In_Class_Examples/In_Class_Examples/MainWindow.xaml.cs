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

namespace In_Class_Examples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MessageBox.Show("Application Loaded");

        }

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtUserInput.Text;
            //MessageBox.Show(userInput);
            lblOutput.Content = userInput;
            //List<Equation> equations = new List<Equation>();
            //Equation problem1 = new Equation();
            //problem1.Left = 15;
            //problem1.Right = 10;

            //equations.Add(problem1);

            //Equation problem2 = new Equation(100,50);

            //equations.Add(problem2);

            //foreach (Equation eq in equations)
            //{
            //    MessageBox.Show($"{eq.Left} + {eq.Right} = {eq.Add()}");
            //    //MessageBox.Show(eq.Left + " + " + eq.Right + " = " + eq.Add());
            //    MessageBox.Show($"{eq.Left}^4 = {eq.LeftToThePower(4)}");
            //}

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double left = Convert.ToDouble(txtUserInput.Text);
            double right;// = double.Parse(txtRight.Text);
            bool isANumber = double.TryParse(txtRight.Text, out right);
            if (isANumber == false)
            {
                MessageBox.Show($"Sorry, {txtRight.Text} is not a number");
            }

            Equation eq = new Equation(left, right);

            MessageBox.Show($"{eq.Left} + {eq.Right} = {eq.Add()}");

            //create an Equation object and assign values from textbox

        }
    }
}
