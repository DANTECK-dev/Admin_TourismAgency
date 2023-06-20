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
    /// Логика взаимодействия для DelTrips.xaml
    /// </summary>
    public partial class DelTrips : Window
    {
        TourismAgencyEntities _entities;

        public DelTrips()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();
            Trip_ID_CB.ItemsSource = _entities.ПОЕЗДКИ.ToList();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";

            try
            {
                _entities.ПОЕЗДКИ.Remove(((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)));
                _entities.SaveChanges();
                Trip_ID_CB.SelectedItem = null;
                Client_ID_CB.Text = "";
                Route_ID_CB.Text = "";
                Start_Date_Of_Trip_TB.Text = "";
                Counts_Of_Days_TB.Text = "";
                Status.Content = "Запись успешно удалена";
            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}
