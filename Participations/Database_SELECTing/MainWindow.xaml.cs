using Database_SELECTing.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Database_SELECTing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private DB_128040_practiceContext db = new DB_128040_practiceContext();
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new DB_128040_practiceContext())
            {
                foreach (var student in db.Students)
                {
                    lstStudents.Items.Add(student);
                }

                foreach (var course in db.Courses)
                {
                    lstCourses.Items.Add(course);
                }
            }

        }

        private void lstStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var student = (Student)lstStudents.SelectedItem;

            MessageBox.Show($"{student.FirstName} {student.LastName} and has a favorite color of {student.FavoriteColor}.");

        }

        private void lstCourses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var course = (Course)lstCourses.SelectedItem;

            MessageBox.Show($"{course.CourseNumber} {course.CourseName} and has a term code of {course.TermCode}.");
        }

        private void lstStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var student = (Student)lstStudents.SelectedItem;

            using (var db = new DB_128040_practiceContext())
            {
                lstRegistrations.Items.Clear();

                //var favColorBlue = db.Students.Where(s => s.FavoriteColor.ToLower().Contains("blue")
                //                                     || s.FavoriteColor.ToLower().Contains("pink"));

                var registrations = db.Registrations.Include(o => o.Course).Include(o => o.Student).Where(r => r.StudentId == student.StudentId).ToList();

                foreach (var registration in registrations)
                {
                    lstRegistrations.Items.Add(registration);
                }
            }

        }

        private void btnMakeRegistration_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;
            var selectedCourse = (Course)lstCourses.SelectedItem;

            if (selectedCourse == null || selectedStudent == null)
            {
                MessageBox.Show("You must select a student and a course");
                return;
            }

            using (var db = new DB_128040_practiceContext())
            {
                Registration r = new Registration();
                r.CourseId = selectedCourse.CourseId;
                r.StudentId = selectedStudent.StudentId;
                r.EnrollmentDate = DateTime.Now;

                db.Registrations.Add(r);

                db.SaveChanges();
            }

        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;

            using (var db = new DB_128040_practiceContext())
            {

                var student = db.Students.Find(selectedStudent.StudentId);

                db.Students.Remove(student);

                db.SaveChanges();

            }
        }

        private void btnMakeRegistration_Copy1_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)lstStudents.SelectedItem;

            using (var db = new DB_128040_practiceContext())
            {

                var student = db.Students.Find(selectedStudent.StudentId);

                student.FirstName = "John";
                
                db.SaveChanges();
            }
        }
    }
}
