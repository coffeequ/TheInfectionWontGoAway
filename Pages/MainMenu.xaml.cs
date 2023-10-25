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

namespace Инфекция_не_пройдет.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void tbCreateInfectDeases(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTwoGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }

        private void btnThreeGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }

        private void btnResultGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }

        private void btnModelingProcess(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }

        private void btnOneGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.OneGroup());
        }
    }
}
