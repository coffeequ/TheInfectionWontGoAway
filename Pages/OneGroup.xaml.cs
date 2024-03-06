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
        // Поле для выгрузки и загрузки информации из файла с группами
        private InformationGroup informationGroup;

        //Поле путь, указывающие где находится файл с информацией о группах людей
        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        /// <summary>
        /// Метод для ввода информации о количестве людей в первой группе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCreateInfectDeases(object sender, RoutedEventArgs e)
        {
            int CountOneGroup = 0;

            try
            {
                CountOneGroup = int.Parse(tbOneGroup.Text);
            }
            catch
            {
                MessageBox.Show("Введите корректное число");
                return;
            }

            informationGroup = new InformationGroup(Path);

            if (CountOneGroup < 0 || CountOneGroup == 0)
            {
                MessageBox.Show("Введите значение больше 0");
            }
            else
            {
                try
                {
                    informationGroup.SaveGroup(CountOneGroup, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    NavigationService.Navigate(new Pages.MainMenu());
                }

                MessageBox.Show($"Данные записались. В первой группе {CountOneGroup} человек");
            }
        }

        /// <summary>
        /// Метод для возврата назад в меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbClose(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }
    }
}
