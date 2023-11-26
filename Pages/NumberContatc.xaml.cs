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
using TheInfectionWontGoAway;

namespace Инфекция_не_пройдет.Pages
{
    /// <summary>
    /// Логика взаимодействия для NumberContatc.xaml
    /// </summary>
    public partial class NumberContatc : Page
    {
        private InformationGroup informationGroup;

        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        List<int> Groups;

        public NumberContatc()
        {
            InitializeComponent();
        }

        private void LoadedGrid(object sender, RoutedEventArgs e)
        {
            informationGroup = new InformationGroup(Path);

            try
            {
                Groups = informationGroup.LoadGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                NavigationService.Navigate(new Pages.MainMenu());
            }

            lbOneGroup.Content = Groups[0];

            lbTwoGroup.Content = Groups[1];

            lbThreeGroup.Content = Groups[2];
        }

        private void tbClose(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }

        private void clCount(object sender, RoutedEventArgs e)
        {
            informationGroup = new InformationGroup(Path);

            try
            {
                Groups = informationGroup.LoadGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                NavigationService.Navigate(new Pages.MainMenu());
            }

            NumberOfIndirectСontacts numberOfIndirectСontacts = new NumberOfIndirectСontacts();

            lbCountContact.Content = numberOfIndirectСontacts.CountContacts(Groups[0], Groups[1], Groups[2]);

            Groups.Add(numberOfIndirectСontacts.CountContacts(Groups[0], Groups[1], Groups[2]));

            informationGroup.SaveResult(Groups);
        }
    }
}
