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
using Инфекция_не_пройдет.Models;

namespace Инфекция_не_пройдет.Pages
{
    /// <summary>
    /// Логика взаимодействия для TwoGroup.xaml
    /// </summary>
    public partial class TwoGroup : Page
    {
        public TwoGroup()
        {
            InitializeComponent();
        }

        private InformationGroup informationGroup;

        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        private void tbCreateInfectDeases(object sender, RoutedEventArgs e)
        {
            int CountTwoGroup = 0;
            try
            {
                CountTwoGroup = int.Parse(tbTwoGroup.Text);
            }
            catch 
            {
                MessageBox.Show("Введите корректное число");
                return;
            }

            informationGroup = new InformationGroup(Path);

            if (CountTwoGroup > 0)
            {
                MessageBox.Show("Введите значение больше 0");
            }
            else
            {
                try
                {
                    informationGroup.SaveGroup(CountTwoGroup, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    NavigationService.Navigate(new Pages.MainMenu());
                }

                MessageBox.Show($"Данные записались. Во второй группе {CountTwoGroup} человек");
            }

        }

        private void tbClose(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }
    }
}
