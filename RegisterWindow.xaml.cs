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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Password;
            var name = NameTextBox.Text;
            var surname = SurnameTextBox.Text;
            var middlename = MiddlenameTextBox.Text;
            var passport = PassportTextBox.Text;
            var phone = PhoneTextBox.Text;

            using (var context = new TourCompanyEntities2())
            {
                var existingUser = context.Customers.FirstOrDefault(u => u.Login == username);

                if (username == null || passport == null || password == null || name == null || surname == null || phone == null)
                {
                    MessageBox.Show("Заполните поля до конца!");
                }
                else if (PasswordTextBox.Password.Length < 5)
                {
                    MessageBox.Show("Длинна пароля должна быть 5+ символов");
                }
                else if (NameTextBox.Text.Any(char.IsDigit) && SurnameTextBox.Text.Any(char.IsDigit) && MiddlenameTextBox.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Имя, фамилия или отчество не могут содержать цифр");
                }
                else if (!PhoneTextBox.Text.Contains('+') || PhoneTextBox.Text.Any(char.IsLetter) || PhoneTextBox.Text.Length < 12 || PhoneTextBox.Text.Length > 12)
                {
                    MessageBox.Show("Номер телефона введен неккоректно");
                }

                else if (existingUser == null)
                {
                    // Создание нового пользователя
                    var newUser = new Customer
                    {
                        Login = username,
                        Pass = password,
                        CustomerName = name,
                        CustomerSurname = surname,
                        CustomerMiddleName = middlename,
                        PassportNumber = passport,
                        PhoneNumber = phone
                    };

                    // Добавление пользователя в контекст и сохранение изменений в БД
                    context.Customers.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("Пользователь успешно зарегистрирован.");
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует.");
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var mainwin = new LoginWindow();
            Application.Current.MainWindow = mainwin;
            mainwin.Show();
            this.Close();
        }
    }
}
