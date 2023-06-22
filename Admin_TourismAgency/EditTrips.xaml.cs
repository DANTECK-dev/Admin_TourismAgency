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
            _entities = new TourismAgencyEntities();       // вытаскиваем всю БД
            Trip_ID_CB.ItemsSource = _entities.ПОЕЗДКИ.ToList();      // вытаскиваем список поездок из БД
        }

        private void Change(object sender, TextChangedEventArgs e)      // функция очищения текста статуса исполнения запроса
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            try
            {
                ПОЕЗДКИ trip = (ПОЕЗДКИ)(Trip_ID_CB.SelectedItem);      // вытаскиваем маршрут из списка ComboBox`a

                // изменяем данные выбраной поездки
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).КЛИЕНТ_ID = int.Parse(Client_ID_CB.Text);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).МАРШРУТ_ID = int.Parse(Route_ID_CB.Text);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).Дата_начала_поездки = DateTime.Parse(Start_Date_Of_Trip_TB.Text);
                _entities.ПОЕЗДКИ.Find(trip.ПОЕЗДКА_ID).Количество_дней = int.Parse(Counts_Of_Days_TB.Text);

                _entities.SaveChanges();         // сохраняем изменения в БД
                Status.Content = "Запись успешно измененна";        // выводим текст об успешном выполнении запроса
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

            // обновляем данные в полях если выбран другая поездка
            Client_ID_CB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).КЛИЕНТ_ID.ToString();
            Route_ID_CB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).МАРШРУТ_ID.ToString();
            Start_Date_Of_Trip_TB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).Дата_начала_поездки.ToString();
            Counts_Of_Days_TB.Text = ((ПОЕЗДКИ)(Trip_ID_CB.SelectedItem)).Количество_дней.ToString();
        }
    }
}
