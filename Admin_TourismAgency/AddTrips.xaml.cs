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
using System.Windows.Shapes;

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для AddTrips.xaml
    /// </summary>
    public partial class AddTrips : Window
    {
        TourismAgencyEntities _entities;

        public AddTrips()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();
            Client_ID_CB.ItemsSource = _entities.КЛИЕНТЫ.ToList();
            Route_ID_CB.ItemsSource = _entities.МАРШРУТЫ.ToList();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ПОЕЗДКИ trip = new ПОЕЗДКИ();

                trip.КЛИЕНТ_ID = int.Parse(Client_ID_CB.Text);
                trip.МАРШРУТ_ID = int.Parse(Route_ID_CB.Text);
                trip.Дата_начала_поездки = DateTime.Parse(Start_Date_Of_Trip_TB.Text);
                trip.Количество_дней = int.Parse(Counts_Of_Days_TB.Text);

                _entities.ПОЕЗДКИ.Add(trip);
                _entities.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Client_ID_CB_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void Route_ID_CB_DropDownClosed(object sender, EventArgs e)
        {

        }
        private void Change(object sender, TextChangedEventArgs e)
        {
            if (Status != null)
                Status.Content = "";
        }
    }
}
