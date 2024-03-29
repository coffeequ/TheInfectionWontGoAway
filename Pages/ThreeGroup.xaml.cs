﻿using System;
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
    /// Логика взаимодействия для ThreeGroup.xaml
    /// </summary>
    public partial class ThreeGroup : Page
    {
        public ThreeGroup()
        {
            InitializeComponent();
        }

        // Поле для выгрузки и загрузки информации из файла с группами
        private InformationGroup informationGroup;

        //Поле путь, указывающие где находится файл с информацией о группах людей
        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        /// <summary>
        /// Метод для записи количества людей во вторую группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCreateInfectDeases(object sender, RoutedEventArgs e)
        {
            int CountThreeGroup = 0;

            try
            {
                CountThreeGroup = int.Parse(tbOneGroup.Text);
            }
            catch 
            {
                MessageBox.Show("Введите корректное число");
                return;
            }

            informationGroup = new InformationGroup(Path);

            if (CountThreeGroup < 0 || CountThreeGroup == 0)
            {
                MessageBox.Show("Введите число больше 0");
            }
            else
            {
                try
                {
                    informationGroup.SaveGroup(CountThreeGroup, 2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    NavigationService.Navigate(new Pages.MainMenu());
                }
                MessageBox.Show($"Данные записались. В третьей группе {CountThreeGroup} человек");
            }

        }

        /// <summary>
        /// Метод для возврата назад в меню авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbClose(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MainMenu());
        }
    }
}
