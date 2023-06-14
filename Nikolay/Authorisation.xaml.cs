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

namespace Nikolay
{
    /// <summary>
    /// Логика взаимодействия для Authorisation.xaml
    /// </summary>
    public partial class Authorisation : Window
    {
        public Authorisation()
        {
            InitializeComponent();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Authorisation_Click(object sender, RoutedEventArgs e)
        {
            string login = Telephone.Text;
            string password = PasswordBox.Password;
            var user = Kit.lk.Users.FirstOrDefault(u => u.Username.ToString() == login && u.Password == password);

            if (user != null)
            {
                Profile profile = new Profile();
                profile.Show();
                this.Close();

                // Создаем экземпляр класса CurrentUser с данными из базы данных
                var currentUser = new CurrentUser(user.UserId, user.Username);
                // Сохраняем экземпляр класса CurrentUser для последующего использования
                Application.Current.Properties["CurrentUser"] = currentUser;

                // Формируем сообщение с приветствием и именем пользователя
                string message = "Здравствуйте, " + currentUser.Username + "!";

                // Выводим сообщение в текстовый блок
                profile.angar.Text = message;
            }

            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
