using Nikolay.Model;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {


        public Profile()
        {
            InitializeComponent();
            GetUserInfo();
        }

        

        private void GetUserInfo()
        {
            var currentUser = Application.Current.Properties["CurrentUser"] as CurrentUser;
            if (currentUser != null)
            {
                 var user = Kit.lk.Users.FirstOrDefault(u => u.UserId == currentUser.UserId);
                if (user != null)
                {
                    user.Username = nameTextBox.Text;
                    int age;
                    if (int.TryParse(ageTextBox.Text, out age))
                    {
                        // Преобразование прошло успешно, значение сохранено в переменную age
                    }
                    else
                    {
                        // Некорректное значение в поле ageTextBox
                        MessageBox.Show("Некорректное значение возраста!");
                    }

                    int phone;
                    if (int.TryParse(telephoneTextBox.Text, out phone))
                    {
                        user.Phone = phone;
                    }
                    else
                    {
                        MessageBox.Show("Некорректное значение телефона!");
                    }

                    user.Pol = genderTextBox.Text;
                    user.Password = passwordTextBox.Text;
                    user.Email = emailTextBox.Text;
                }
            }
        }

        private void Saves_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = Application.Current.Properties["CurrentUser"] as CurrentUser;
            if (currentUser != null)
            {
                // Получаем пользователя из базы данных
                var user = Kit.lk.Users.FirstOrDefault(u => u.UserId == currentUser.UserId);
                if (user != null)
                {
                    bool isUpdated = false;  // Флаг, указывающий, были ли внесены изменения

                    // Проверяем и обновляем имя пользователя
                    if (!string.IsNullOrEmpty(nameTextBox.Text) && user.Username != nameTextBox.Text)
                    {
                        user.Username = nameTextBox.Text;
                        isUpdated = true;
                    }

                    // Проверяем и обновляем возраст
                    int age;
                    if (!string.IsNullOrEmpty(ageTextBox.Text) && int.TryParse(ageTextBox.Text, out age))
                    {
                        user.Age = age;
                        isUpdated = true;
                    }

                    else if (!string.IsNullOrEmpty(ageTextBox.Text))
                    {
                        MessageBox.Show("Некорректное значение возраста!");
                    }

                    // Проверяем и обновляем телефон
                    int phone;
                    if (int.TryParse(telephoneTextBox.Text, out phone) && user.Phone != phone)
                    {
                        user.Phone = phone;
                        isUpdated = true;
                    }
                    else if (!string.IsNullOrEmpty(telephoneTextBox.Text))
                    {
                        MessageBox.Show("Некорректное значение телефона!");
                    }

                    // Проверяем и обновляем пол
                    if (!string.IsNullOrEmpty(genderTextBox.Text) && user.Pol != genderTextBox.Text)
                    {
                        user.Pol = genderTextBox.Text;
                        isUpdated = true;
                    }

                    // Проверяем и обновляем пароль
                    if (!string.IsNullOrEmpty(passwordTextBox.Text) && user.Password != passwordTextBox.Text)
                    {
                        user.Password = passwordTextBox.Text;
                        isUpdated = true;
                    }

                    // Проверяем и обновляем email
                    if (!string.IsNullOrEmpty(emailTextBox.Text) && user.Email != emailTextBox.Text)
                    {
                        user.Email = emailTextBox.Text;
                        isUpdated = true;
                    }

                    // Сохраняем изменения в базе данных, если были внесены изменения
                    if (isUpdated)
                    {
                        try
                        {
                            Kit.lk.SaveChanges();
                            MessageBox.Show("Данные успешно сохранены!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет изменений для сохранения.");
                    }
                }
            }
        }



        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Authorisation authorisation = new Authorisation();
            authorisation.Show();
            this.Close();
        }

        private void Mainn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void calculator_Click(object sender, RoutedEventArgs e)
        {
            Kalkulator kalkulator = new Kalkulator();
            kalkulator.Show();
            this.Close();
        }

        private void btProfil_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

