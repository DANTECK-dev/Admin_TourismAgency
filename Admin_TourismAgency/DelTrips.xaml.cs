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
            _entities = new TourismAgencyEntities();       // вытаскиваем всю БД
            Trip_ID_CB.ItemsSource = _entities.ПОЕЗДКИ.ToList();      // вытаскиваем список поездок из БД
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.ПОЕЗДКИ.Remove(((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)));       // удаление поездки из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленой поездки
                Trip_ID_CB.SelectedItem = null;
                Client_ID_CB.Text = "";
                Route_ID_CB.Text = "";
                Start_Date_Of_Trip_TB.Text = "";
                Counts_Of_Days_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Trip_ID_CB.ItemsSource = _entities.ПОЕЗДКИ.ToList();      // обновляем список поездок
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Trips_ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            if (Trip_ID_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбрана другая поездка
            Client_ID_CB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).КЛИЕНТ_ID.ToString();
            Route_ID_CB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).МАРШРУТ_ID.ToString();
            Start_Date_Of_Trip_TB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).Дата_начала_поездки.ToString();
            Counts_Of_Days_TB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).Количество_дней.ToString();
        }
    }
}
