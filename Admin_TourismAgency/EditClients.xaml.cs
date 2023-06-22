using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditClients.xaml
    /// </summary>
    public partial class EditClients : Window
    {
        TourismAgencyEntities _entities;

        public EditClients()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();
            Client_ID_CB.ItemsSource = _entities.КЛИЕНТЫ.ToList();
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
                КЛИЕНТЫ client = (КЛИЕНТЫ)(Client_ID_CB.SelectedItem);      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.КЛИЕНТЫ.Find(client.КЛИЕНТ_ID).ФИО = FIO_TB.Text;
                _entities.КЛИЕНТЫ.Find(client.КЛИЕНТ_ID).Данные_паспорта = Passport_TB.Text;
                _entities.КЛИЕНТЫ.Find(client.КЛИЕНТ_ID).Пароль = Password_TB.Text;

                _entities.SaveChanges();         // сохраняем изменения в БД
                Status.Content = "Запись успешно измененна";        // выводим текст об успешном выполнении запроса
            }
            catch (Exception ex)
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Client_ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";
            if (Client_ID_CB.SelectedItem == null) return;
            FIO_TB.Text = ((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)).ФИО;
            Passport_TB.Text = ((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)).Данные_паспорта;
            Password_TB.Text = ((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)).Пароль;
        }
    }
}
