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
    /// Логика взаимодействия для Kalkulator.xaml
    /// </summary>
    public partial class Kalkulator : Window
    {
        private DiplKolEntities lk;
        private ObservableCollection<Calculation> calculations;

        public Kalkulator()
        {
            InitializeComponent();
            lk = new DiplKolEntities();
            calculations = new ObservableCollection<Calculation>();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int komnat = int.Parse(komnatTextBox.Text);
                int etajey = int.Parse(etajeyTextBox.Text);
                int sanuzlov = int.Parse(sanuzlovTextBox.Text);
                int vannih = int.Parse(vannihTextBox.Text);
                int balkonov = int.Parse(balkonovTextBox.Text);
                stoimostTextBox.Text = "";

                decimal basePrice = 8000000;
                decimal stoimost = komnat * 150000 + etajey * 200000 + sanuzlov * 100000 + vannih * 100000 + balkonov * 120000;
                decimal totalStoimost = basePrice + stoimost;
                stoimostTextBox.Text = totalStoimost.ToString();

                Calculation calculation = new Calculation
                {
                    Date = DateTime.Now,
                    Komnat = komnat,
                    Etajey = etajey,
                    Sanuzlov = sanuzlov,
                    Vannih = vannih,
                    Balkonov = balkonov,
                    Stoimost = totalStoimost
                };

                lk.HousePrefer.Add(new HousePrefer
                {
                    Date = calculation.Date,
                    Komnat = calculation.Komnat,
                    Etajey = calculation.Etajey,
                    Sanuzlov = calculation.Sanuzlov,
                    Vannih = calculation.Vannih,
                    Balkonov = calculation.Balkonov,
                    Stoimost = calculation.Stoimost,
                });

                lk.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка расчета стоимости недвижимости: " + ex.Message);
            }
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
           Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void btProfil_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
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

        private void calculator_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
