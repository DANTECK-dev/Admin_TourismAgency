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
    /// Логика взаимодействия для EditRoutes.xaml
    /// </summary>
    public partial class EditRoutes : Window
    {
        TourismAgencyEntities _entities;

        public EditRoutes()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();
            Route_ID_CB.ItemsSource = _entities.МАРШРУТЫ.ToList();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {
                МАРШРУТЫ route = (МАРШРУТЫ)(Route_ID_CB.SelectedItem);
                _entities.МАРШРУТЫ.Find(route.МАРШРУТ_ID).Страна_назначения = Destination_Country_TB.Text;
                _entities.МАРШРУТЫ.Find(route.МАРШРУТ_ID).Цель_поездки = Purpose_Of_Trip_TB.Text;
                _entities.МАРШРУТЫ.Find(route.МАРШРУТ_ID).Стоимость_1_дня_пребывания = int.Parse(Cost_Of_Day_Stay_TB.Text);
                _entities.МАРШРУТЫ.Find(route.МАРШРУТ_ID).Стоимость_транспортных_услуг = int.Parse(Cost_Of_Transport_Services_TB.Text);
                _entities.МАРШРУТЫ.Find(route.МАРШРУТ_ID).Стоимость_оформления_визы = int.Parse(Cost_Of_Obtaining_Visa_TB.Text);
                _entities.SaveChanges();
                Status.Content = "Запись успешно измененна";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
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

        private void Change(object sender, TextChangedEventArgs e)
        {
            if (Status != null)
                Status.Content = "";
        }
    }
}
