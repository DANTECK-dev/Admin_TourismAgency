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
    /// Логика взаимодействия для EditTrips.xaml
    /// </summary>
    public partial class EditTrips : Window
    {
        TourismAgencyEntities _entities;

        public EditTrips()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();
            Trip_ID_CB.ItemsSource = _entities.ПОЕЗДКИ.ToList();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ПОЕЗДКИ trip = (ПОЕЗДКИ)(Trip_ID_CB.SelectedItem);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).КЛИЕНТ_ID = int.Parse(Client_ID_CB.Text);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).МАРШРУТ_ID = int.Parse(Route_ID_CB.Text);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).Дата_начала_поездки = DateTime.Parse(Start_Date_Of_Trip_TB.Text);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).Количество_дней = int.Parse(Counts_Of_Days_TB.Text);
                _entities.SaveChanges();
                Status.Content = "Запись успешно измененна";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void Trips_ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";
            if (Trip_ID_CB.SelectedItem == null) return;
            Client_ID_CB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).КЛИЕНТ_ID.ToString();
            Route_ID_CB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).МАРШРУТ_ID.ToString();
            Start_Date_Of_Trip_TB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).Дата_начала_поездки.ToString();
            Counts_Of_Days_TB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).Количество_дней.ToString();
        }

        private void Change(object sender, TextChangedEventArgs e)
        {
            if (Status != null)
                Status.Content = "";
        }
    }
}
