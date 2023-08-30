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

namespace FirstWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();

            //read csv file from computer
            string[] lines =File.ReadAllLines("Students.csv");

          

            //loop through each line skipping the first

            foreach (string line in lines.Skip(1))
            {

                //split the line into parts
                string[] parts = line.Split(',');

                //create a student object
                Student student = new Student();
                student.Name = $"{parts[1]}, {parts[0]}";
                student.Birthdate = Convert.ToDateTime(parts[2]);

                //add the student to the list
                //students.Add(student);
                lstStudents.Items.Add(student);
            }

        }

        private void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            DateTime? birthdate = Convert.ToDateTime(txtDob.Text);

            Student student = new Student(); 
            student.Birthdate = birthdate;
            student.Name = name;

            //students.Add(student);
            lstStudents.Items.Add(student);
            ClearTextBoxes();

            MessageBox.Show($"{student.Name} was created and they are {student.CalculateAge().ToString("N0")} years old.");
        }

        private void btnCreateStudent_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.Green;
        }

        private void btnCreateStudent_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.Red;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            //clear the textboxes
            txtName.Text = string.Empty;
            txtDob.Text = string.Empty;
            txtName.Focus();
        }

        private void lstStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student selectedStudent = (Student)lstStudents.SelectedItem;
            MessageBox.Show($"{selectedStudent.Name} was created and they are {selectedStudent.CalculateAge().ToString("N0")} years old.");
        }
    }
}
