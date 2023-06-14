using Nikolay.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public ObservableCollection<Calculation> calculations;

        public Dashboard()
        {
            InitializeComponent();
            calculations = new ObservableCollection<Calculation>();
            HistoryDataGrid.ItemsSource = calculations;

            LoadCalculations();
        }

        private void LoadCalculations()
        {
            using (var lk = new DiplKolEntities())
            {
                // Извлекаем расчеты из базы данных
                var calculationList = lk.HousePrefer.ToList();

                // Добавляем расчеты в коллекцию calculations
                foreach (var calculation in calculationList)
                {
                    calculations.Add(new Calculation
                    {
                        Date = (DateTime)calculation.Date,
                        Komnat = (int)calculation.Komnat,
                        Etajey = (int)calculation.Etajey,
                        Sanuzlov = (int)calculation.Sanuzlov,
                        Vannih = (int)calculation.Vannih,
                        Balkonov = (int)calculation.Balkonov,
                        Stoimost = (decimal)calculation.Stoimost
                    });
                }
            }
        }
        private void Mainn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Authorisation authorisation = new Authorisation();
            authorisation.Show();
            this.Close();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
