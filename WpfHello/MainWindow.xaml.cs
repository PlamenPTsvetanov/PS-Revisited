using System.Windows;
using System.Windows.Controls;

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            listBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            james.Content = "James";
            listBox.Items.Add(david);

            listBox.SelectedItem = james;
        }

        private void btnHello_click(object sender, RoutedEventArgs e)
        {
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }

      
    }
}
