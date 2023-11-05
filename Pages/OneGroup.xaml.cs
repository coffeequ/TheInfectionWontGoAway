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
    /// Логика взаимодействия для OneGroup.xaml
    /// </summary>
    public partial class OneGroup : Page
    {
        public OneGroup()
        {
            InitializeComponent();
        }

        private InformationGroup informationGroup;

        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        private void tbCreateInfectDeases(object sender, RoutedEventArgs e)
        {
            int CountOneGroup = int.Parse(tbOneGroup.Text);

            informationGroup = new InformationGroup(Path);

            try
            {
                informationGroup.SaveGroup(CountOneGroup, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                NavigationService.Navigate(new Pages.MainMenu());
            }

            MessageBox.Show($"Данные записались. В первой группе {CountOneGroup} человек");
        }

        private void tbClose(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }
    }
}
