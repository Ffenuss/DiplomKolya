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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nikolay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            // Загрузка компаний из базы данных
            var companies = Kit.lk.Contractors.ToList();

            // Присвоение списка компаний свойству ItemsSource ListBox
            CompaniesListBox.ItemsSource = companies;
        }

        private void CompaniesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбора компании из списка
            var selectedCompany = (Contractors)CompaniesListBox.SelectedItem;
            if (selectedCompany != null)
            {
                string message = $"Контактное лицо: {selectedCompany.ContactName}\nEmail: {selectedCompany.Email}\nТелефон: {selectedCompany.Phone}\nОписание: {selectedCompany.Description}";
                MessageBox.Show(message, "Данные компании");
            }
        }
        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Authorisation authorisation = new Authorisation();
            authorisation.Show();
            this.Close();
        }

        private void btProfil_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void calculator_Click(object sender, RoutedEventArgs e)
        {
            Kalkulator kalkulator = new Kalkulator();
            kalkulator.Show();
            this.Close();
        }

        private void Mainn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
