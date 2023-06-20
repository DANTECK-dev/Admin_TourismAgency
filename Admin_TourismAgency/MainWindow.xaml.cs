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

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenViewRoutes(object sender, RoutedEventArgs e)
        {
            ViewRoutes window = new ViewRoutes();
            window.Show();
        }

        private void OpenViewClients(object sender, RoutedEventArgs e)
        {
            ViewClients window = new ViewClients();
            window.Show();
        }

        private void OpenViewTrips(object sender, RoutedEventArgs e)
        {
            ViewTrips window = new ViewTrips();
            window.Show();
        }

        private void OpenEditRoutes(object sender, RoutedEventArgs e)
        {
            EditRoutes window = new EditRoutes();
            window.Show();
        }

        private void OpenEditClients(object sender, RoutedEventArgs e)
        {
            EditClients window = new EditClients();
            window.Show();
        }

        private void OpenEditTrips(object sender, RoutedEventArgs e)
        {
            EditTrips window = new EditTrips();
            window.Show();
        }

        private void OpenAddRoutes(object sender, RoutedEventArgs e)
        {
            AddRoutes window = new AddRoutes();
            window.Show();
        }

        private void OpenAddClients(object sender, RoutedEventArgs e)
        {
            AddClients window = new AddClients();
            window.Show();
        }

        private void OpenAddTrips(object sender, RoutedEventArgs e)
        {
            AddTrips window = new AddTrips();
            window.Show();
        }

        private void OpenDelRoutes(object sender, RoutedEventArgs e)
        {
            DelRoutes window = new DelRoutes();
            window.Show();
        }

        private void OpenDelClients(object sender, RoutedEventArgs e)
        {
            DelClients window = new DelClients();
            window.Show();
        }

        private void OpenDelTrips(object sender, RoutedEventArgs e)
        {
            DelTrips window = new DelTrips();
            window.Show();
        }
    }
}
