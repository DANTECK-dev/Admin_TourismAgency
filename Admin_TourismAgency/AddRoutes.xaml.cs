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
    /// Логика взаимодействия для AddRoutes.xaml
    /// </summary>
    public partial class AddRoutes : Window
    {
        public AddRoutes()
        {
            InitializeComponent();
        }
        private void Change(object sender, TextChangedEventArgs e)
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {

                TourismAgencyEntities entities = new TourismAgencyEntities();
                МАРШРУТЫ route = new МАРШРУТЫ();

                route.Страна_назначения = Destination_Country_TB.Text;
                route.Цель_поездки = Purpose_Of_Trip_TB.Text;
                route.Стоимость_1_дня_пребывания = int.Parse(Cost_Of_Day_Stay_TB.Text);
                route.Стоимость_транспортных_услуг = int.Parse(Cost_Of_Transport_Services_TB.Text);
                route.Стоимость_оформления_визы = int.Parse(Cost_Of_Obtaining_Visa_TB.Text);

                entities.МАРШРУТЫ.Add(route);
                entities.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
