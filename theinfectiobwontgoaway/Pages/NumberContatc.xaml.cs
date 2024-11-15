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
using Epidemiology;

namespace Инфекция_не_пройдет.Pages
{
    //**********************************************************************************************************************
    //* Название программы: "Библиотека "Эпидемиология""                                                                   *
    //*                                                                                                                    *
    //* Назначение программы: Бибилиотека предназначена для калькуляции непрямых контактов между первой и третьей группой  *
    //*                                                                                                                    *
    //* Разработчик: студент группы ПР-330/б Пугач С.Е.                                                                    *
    //*                                                                                                                    *
    //* Версия: 1.0                                                                                                        *
    //**********************************************************************************************************************

    /// <summary>
    /// Логика взаимодействия для NumberContatc.xaml
    /// </summary>
    public partial class NumberContatc : Page
    {
        // Поле для выгрузки и загрузки информации из файла с группами
        private InformationGroup informationGroup;

        // Поле путь указывающие где находится файл с информацией о группах людей
        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        // Поле лист со всеми группами
        List<int> Groups;

        public NumberContatc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для вывода информации о группах 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод возврата назад в меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbClose(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }

        /// <summary>
        /// Метод для вывода количества непрямых контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            int countContacts = numberOfIndirectСontacts.CountContacts(Groups[0], Groups[1], Groups[2]);

            lbCountContact.Content = countContacts;

            Groups.Add(countContacts);

            informationGroup.SaveResult(Groups);
        }
    }
}
