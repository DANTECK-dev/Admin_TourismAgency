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
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        public AddClients()
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
                КЛИЕНТЫ client = new КЛИЕНТЫ();     // новый пустой клиент

                // заполнение нового клиента данными
                client.ФИО = FIO_TB.Text;       
                client.Данные_паспорта = Passport_TB.Text;
                client.Пароль = Password_TB.Text;

                entities.КЛИЕНТЫ.Add(client);       // добавляем клиента в БД
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
