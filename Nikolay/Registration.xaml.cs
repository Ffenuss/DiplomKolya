using Nikolay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            DiplKolEntities lk = Kit.lk;
            string mes = "";

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
                mes += "Введите имя\n";
            else if (!IsAlphabetic(FirstNameTextBox.Text))
                mes += "Имя должно содержать только буквы\n";
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
                mes += "Введите пароль\n";
            else if (PasswordBox.Password.Length < 6)
                mes += "Пароль должен содержать не менее 6 символов\n";
            else if (PasswordBox.Password.Length > 25)
                mes += "Пароль должен содержать не более 25 символов\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                return;
            }

            Model.Users newUser = new Model.Users();
            {
                newUser.Username = FirstNameTextBox.Text.Substring(0, Math.Min(FirstNameTextBox.Text.Length, 25));
                newUser.Password = PasswordBox.Password;
            }

            Kit.lk.Users.Add(newUser);
            Kit.lk.SaveChanges();
            MessageBox.Show("Регистрация успешна");

            Authorisation authorisation = new Authorisation();
            authorisation.Show();
            this.Close();
        }
        private bool IsAlphabetic(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
       

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            Authorisation authorisation = new Authorisation();
            authorisation.Show();
            this.Close();
        }
    }
}
