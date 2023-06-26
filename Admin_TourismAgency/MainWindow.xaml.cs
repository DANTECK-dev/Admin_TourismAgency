using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Admin_TourismAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // логин и пароль
        /*string _login = "RwNydpKbI@O{nk8V{7I|p2hW#%IzGxS?7fDA4R2dkb6R21rt3@Kq3KgJx8}fE2vc~VmVkKV0Q2%b?WyMSEAQSh$iqE~qkk1RH#q" +
            "jSS~5s1QXMpCN32A%$U|fLMTX$TbFG?PSasfzHkEJBeN~NEKPXE{{H$Qed$pe3ly2PnzT?L5WsGmFP}uOY*CQ0djBhO19Rx9HSkywg~xSQr47OP";
        string _password = "#I#lvGKDJMM%B2tbi4Hj}~aeNVwKB~N9~ltC$tlBiI{K|gg{1~~IlMH~nWq%}h#2*%@Xk}cg1e{Hh%EazDIjcU88v1tQYK$|" +
            "Yg@qkxB3{kG~|JV~*gRcefY$OXrOyPAn97ionSaz#VgL92~87pVjX{4G1pLgi||2C@0S$y#}dKrZ~2ai|msCnFbXwS8J1q7R2G8nB%apGtNbzv@" +
            "dtQ69b5fNMSAcFA1wO3vW$8mXNa5F6rDtHYTonmltRxanu8x?5eTYa$iLF4DFC72323LvIRbyN#K0q?|wHBdwyW#Y%2Oun@6Qd#YWMv}ldNj*fT";*/

        string _login = "admin";
        string _password = "admin";

        public MainWindow()
        {
            InitializeComponent();
            Login_G.Visibility = Visibility.Visible;        // форма входа видима
            Registered_G.Visibility = Visibility.Hidden;        // форма авторизированого админа скрыта

            // очищаем форму
            Login_TB.Text = "";
            Password_TB.Text = "";

            //this.Background = new ImageBrush(new BitmapImage(new Uri("C:/Images/bg1.png")));
        }

        private void BG_Image_BT_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                this.Background = new ImageBrush(new BitmapImage(new Uri(filename)));
            }
        }

        private void Login_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            // при вводе логина проверяется правильность ввдененых данных и если все правильно,
            // то открывается форма авторизированного админа, а форма входа скрывается
            if (Login_TB.Text == _login && Password_TB.Text == _password)
            {
                Login_G.Visibility = Visibility.Hidden;
                Registered_G.Visibility = Visibility.Visible;
            }
        }

        private void Password_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            // при вводе логина проверяется правильность ввдененых данных и если все правильно,
            // то открывается форма авторизированного админа, а форма входа скрывается
            if (Login_TB.Text == _login && Password_TB.Text == _password)
            {
                Login_G.Visibility = Visibility.Hidden;
                Registered_G.Visibility = Visibility.Visible;
            }
        }

        // обработки нажатий на кнопки меню, открываются соответствующие окна
        // просмотр
        private void OpenViewRoutes(object sender, RoutedEventArgs e)       // просмотр маршрутов
        {
            ViewRoutes window = new ViewRoutes();
            window.Show();
        }

        private void OpenViewClients(object sender, RoutedEventArgs e)       // просмотр клиентов
        {
            ViewClients window = new ViewClients();
            window.Show();
        }

        private void OpenViewTrips(object sender, RoutedEventArgs e)       // просмотр поездок
        {
            ViewTrips window = new ViewTrips();
            window.Show();
        }

        // редактирование
        private void OpenEditRoutes(object sender, RoutedEventArgs e)       // редактирование маршрута
        {
            EditRoutes window = new EditRoutes();
            window.Show();
        }

        private void OpenEditClients(object sender, RoutedEventArgs e)       // редактирование клиента
        {
            EditClients window = new EditClients();
            window.Show();
        }

        private void OpenEditTrips(object sender, RoutedEventArgs e)       // редактирование поездки
        {
            EditTrips window = new EditTrips();
            window.Show();
        }

        // добавление
        private void OpenAddRoutes(object sender, RoutedEventArgs e)       // добавление маршрута
        {
            AddRoutes window = new AddRoutes();
            window.Show();
        }

        private void OpenAddClients(object sender, RoutedEventArgs e)       // добавление клиента
        {
            AddClients window = new AddClients();
            window.Show();
        }

        private void OpenAddTrips(object sender, RoutedEventArgs e)       // добавление поездки
        {
            AddTrips window = new AddTrips();
            window.Show();
        }

        // удаление
        private void OpenDelRoutes(object sender, RoutedEventArgs e)       // удаление маршрута
        {
            DelRoutes window = new DelRoutes();
            window.Show();
        }

        private void OpenDelClients(object sender, RoutedEventArgs e)       // удаление клиента
        {
            DelClients window = new DelClients();
            window.Show();
        }

        private void OpenDelTrips(object sender, RoutedEventArgs e)       // удаление поездки
        {
            DelTrips window = new DelTrips();
            window.Show();
        }
    }
}
