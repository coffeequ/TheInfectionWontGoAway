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

        public delegate void CloseWin();

        public static event CloseWin closewin;

        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        private void btnTwoGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.TwoGroup());
        }

        private void btnThreeGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ThreeGroup());
        }

        private void btnResultGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.NumberContatc());
        }

        private void btnModelingProcess(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ModelingProcess());
        }

        private void btnOneGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.OneGroup());
        }

        private void gridLoaded(object sender, RoutedEventArgs e)
        {
            Models.InformationGroup informationGroup = new Models.InformationGroup(Path);

            informationGroup.CreateFileGroup();
        }

        private void btnSpravka(object sender, RoutedEventArgs e)
        {
            new Spravka().Show();
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            closewin();
        }
    }
}
