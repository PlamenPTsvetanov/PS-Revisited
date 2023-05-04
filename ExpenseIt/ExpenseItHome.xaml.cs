using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> PersonsChecked { get; set; }
        public DateTime LastChecked { 
            get;
            set; 
        }
        public List<Person> ExpenseDataSource { get; set; }
        public string MainCaptionText { get; set; }
        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report :";
            PersonsChecked = new ObservableCollection<string>();   
            LastChecked = DateTime.Now;
            ExpenseDataSource = new List<Person>()
            {
                new Person()
                {
                    Name="Mike",
                    Expenses = new List<Expense>()
                        {
                            new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
                            new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                        }
                },
                new Person()
                {
                    Name ="Lisa",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                        new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                    }
                },
                new Person()
                {
                    Name="John",
                    Department ="Engineering",
                    Expenses = new List<Expense>(){
                        new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                        new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                        new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                    }
                },
                new Person()
                {
                    Name="Mary",
                    Department ="Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name="Theo",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name="James",
                    Department ="Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 },
                        new Expense() { ExpenseType="Car", ExpenseAmount=1100 },
                        new Expense() { ExpenseType="Apartment", ExpenseAmount=12100 }
                    }
                },
                new Person()
                {
                    Name="David",
                    Department ="HR",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Existing", ExpenseAmount=100000 }
                    }
                }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LastChecked = DateTime.Now;
            Person person = (from ex in ExpenseDataSource where ex.Name.Equals(((Person)peopleListBox.SelectedItem).Name) select ex).First();
            ExpenseReport report = new ExpenseReport(person);
            report.Show();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
            PersonsChecked.Add(((Person)peopleListBox.SelectedItem).Name);
        }
    }

    public class Expense
    {
        public string ExpenseType { get; set; }
        public double ExpenseAmount { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
