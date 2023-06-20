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
    /// Логика взаимодействия для DelRoutes.xaml
    /// </summary>
    public partial class DelRoutes : Window
    {
        TourismAgencyEntities _entities;

        public DelRoutes()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();
            Route_ID_CB.ItemsSource = _entities.МАРШРУТЫ.ToList();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";

            try
            {
                _entities.МАРШРУТЫ.Remove(((МАРШРУТЫ)(Route_ID_CB.SelectedItem)));
                _entities.SaveChanges();
                Route_ID_CB.SelectedItem = null;
                Destination_Country_TB.Text = "";
                Purpose_Of_Trip_TB.Text = "";
                Cost_Of_Day_Stay_TB.Text = "";
                Cost_Of_Transport_Services_TB.Text = "";
                Cost_Of_Obtaining_Visa_TB.Text = "";
                Status.Content = "Запись успешно удалена";
            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Route_ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";
            if (Route_ID_CB.SelectedItem == null) return;
            Destination_Country_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Страна_назначения;
            Purpose_Of_Trip_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Цель_поездки;
            Cost_Of_Day_Stay_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Стоимость_1_дня_пребывания.ToString();
            Cost_Of_Transport_Services_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Стоимость_транспортных_услуг.ToString();
            Cost_Of_Obtaining_Visa_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Стоимость_оформления_визы.ToString();
        }
    }
}
