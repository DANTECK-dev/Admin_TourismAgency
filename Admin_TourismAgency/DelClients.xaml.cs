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
    /// Логика взаимодействия для DelClients.xaml
    /// </summary>
    public partial class DelClients : Window
    {
        TourismAgencyEntities _entities;

        public DelClients()
        {
            InitializeComponent();
            _entities = new TourismAgencyEntities();       // вытаскиваем всю БД
            Client_ID_CB.ItemsSource = _entities.КЛИЕНТЫ.ToList();      // вытаскиваем список клиентов из БД
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.КЛИЕНТЫ.Remove(((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                Client_ID_CB.SelectedItem = null;
                FIO_TB.Text = "";
                Passport_TB.Text = "";
                Password_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Client_ID_CB.ItemsSource = _entities.КЛИЕНТЫ.ToList();      // обновляем список клиентов
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Client_ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            if (Client_ID_CB.SelectedItem == null) return; 
            
            // обновляем данные в полях если выбран другой пользователь
            FIO_TB.Text = ((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)).ФИО;
            Passport_TB.Text = ((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)).Данные_паспорта;
            Password_TB.Text = ((КЛИЕНТЫ)(Client_ID_CB.SelectedItem)).Пароль;
        }
    }
}
