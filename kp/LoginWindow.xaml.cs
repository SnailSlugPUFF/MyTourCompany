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

namespace kp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TourCompanyEntities1())
            {
                var username = UsernameTextBox.Text;
                var password = PasswordTextBox.Password;

                var user = context.Users.FirstOrDefault(u => u.Login == username && u.Pass == password);

                if (user != null)
                {
                    var mainWin = new MainWindow();
                    Application.Current.MainWindow = mainWin;
                    mainWin.Show();
                    this.Close();
                }
                else if(user != null && user.Login == "admin" && user.Pass == "admin")
                {
                    MessageBox.Show("Функции администратора недоступны. Для доступа к функциям администратора нажмите соответствующую кнопку");
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TourCompanyEntities1())
            {
                var username = UsernameTextBox.Text;
                var password = PasswordTextBox.Password;

                var user = context.Users.FirstOrDefault(u => u.Login == username && u.Pass == password);

                if (user != null && user.Pass == "admin" && user.Login == "admin")
                {
                    var mainWin = new AdminWindow();
                    Application.Current.MainWindow = mainWin;
                    mainWin.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Данные администратора неверны");
                }
            }
        }
    }
}
