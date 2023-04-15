using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using StudentInfoSystem;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using UserLogin;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = @"Server = localhost" + "\\" + "SQLEXPRESS; Database = Student_Info_Database; Trusted_Connection = True;";

        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in StudentInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }

            foreach (var item in PersonalInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        { 
            foreach (var item in PersonalInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
            foreach (var item in StudentInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in StudentInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }

            foreach (var item in PersonalInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents.First();
            tbFirstName.Text = student.Name;
            tbMiddleName.Text = student.MiddleName;
            tbLastName.Text = student.FamilyName;
            tbFaculty.Text = student.Faculty;
            tbSpecialty.Text = student.Specialty;
            tbOks.Text = student.EducationLevel;
            tbStatus.Text = StudStatusChoices.First();
            tbFacNum.Text = student._facultyNumber;
            tbCourse.Text = student.Course;
            tbStream.Text = student.FacultyGroup;
            tbGroup.Text = student.LocalizedGroup;

            img.Source = new BitmapImage(new Uri("D:\\Coding\\C#\\exercises_revamped\\StudentInfoSystem\\image.jpg"));
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            StudentValidation validate = new StudentValidation();
            if (validate.TestStudentsIfEmpty())
            {
                StudentData studentData = new StudentData();
                studentData.copyTestStudents();
            }

            if (UserData.checkIfPresentUsers())
            {
                UserData.copyTestUsers();
            }

        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            Debug.WriteLine(ConnectionString);
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlquery = "SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
    }
}
