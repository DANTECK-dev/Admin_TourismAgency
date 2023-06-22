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
        private void Change(object sender, TextChangedEventArgs e)      // функция очищения текста статуса исполнения запроса
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)        // обработка нажатия на кнопку "Добавить"
        {
            try
            {

                TourismAgencyEntities entities = new TourismAgencyEntities();       // вытаскиваем всю БД
                МАРШРУТЫ route = new МАРШРУТЫ();     // новый пустой маршрут

                // заполнение нового маршрута данными
                route.Страна_назначения = Destination_Country_TB.Text;
                route.Цель_поездки = Purpose_Of_Trip_TB.Text;
                route.Стоимость_1_дня_пребывания = int.Parse(Cost_Of_Day_Stay_TB.Text);
                route.Стоимость_транспортных_услуг = int.Parse(Cost_Of_Transport_Services_TB.Text);
                route.Стоимость_оформления_визы = int.Parse(Cost_Of_Obtaining_Visa_TB.Text);

                entities.МАРШРУТЫ.Add(route);       // добавляем маршрута в БД
                entities.SaveChanges();     // сохраняем изменения в БД
                Status.Content = "Запись успешно добавлена";        // выводим текст об успешном выполнении запроса

            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
