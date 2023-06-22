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
            _entities = new TourismAgencyEntities();       // вытаскиваем всю БД
            Route_ID_CB.ItemsSource = _entities.МАРШРУТЫ.ToList();      // обновляем список маршрутов
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.МАРШРУТЫ.Remove(((МАРШРУТЫ)(Route_ID_CB.SelectedItem)));       // удаление маршрута из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого маршрута
                Route_ID_CB.SelectedItem = null;
                Destination_Country_TB.Text = "";
                Purpose_Of_Trip_TB.Text = "";
                Cost_Of_Day_Stay_TB.Text = "";
                Cost_Of_Transport_Services_TB.Text = "";
                Cost_Of_Obtaining_Visa_TB.Text = "";
                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Route_ID_CB.ItemsSource = _entities.МАРШРУТЫ.ToList();      // обновляем список маршрутов
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Route_ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";            // обновляем данные в полях если выбран другой пользователь
            if (Route_ID_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбран другой маршрут
            Destination_Country_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Страна_назначения;
            Purpose_Of_Trip_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Цель_поездки;
            Cost_Of_Day_Stay_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Стоимость_1_дня_пребывания.ToString();
            Cost_Of_Transport_Services_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Стоимость_транспортных_услуг.ToString();
            Cost_Of_Obtaining_Visa_TB.Text = ((МАРШРУТЫ)(Route_ID_CB.SelectedItem)).Стоимость_оформления_визы.ToString();
        }
    }
}
