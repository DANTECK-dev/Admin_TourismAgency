using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            _entities = new TourismAgencyEntities();       // вытаскиваем всю БД
            Client_ID_CB.ItemsSource = _entities.КЛИЕНТЫ.ToList();      // вытаскиваем список клиентов из БД
            Route_ID_CB.ItemsSource = _entities.МАРШРУТЫ.ToList();      // вытаскиваем список маршрутов из БД
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

                ПОЕЗДКИ trip = new ПОЕЗДКИ();     // новая пустая поездка

                // заполнение нового клиента данными
                trip.КЛИЕНТ_ID = int.Parse(Client_ID_CB.Text);
                trip.МАРШРУТ_ID = int.Parse(Route_ID_CB.Text);
                trip.Дата_начала_поездки = DateTime.Parse(Start_Date_Of_Trip_TB.Text);
                trip.Количество_дней = int.Parse(Counts_Of_Days_TB.Text);

                _entities.ПОЕЗДКИ.Add(trip);       // добавляем поездку в БД
                _entities.SaveChanges();     // сохраняем изменения в БД
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
