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
        //Поле ссылающиеся на метод CloseWin()
        public delegate void CloseWin();

        // Поле с событием для закрытия окна с меню
        public static event CloseWin closewin;

        // Поле с путем к информации в группах
        private readonly string Path = $"{Environment.CurrentDirectory}\\Groups.txt";

        /// <summary>
        /// Метод для перехода на страницу заполнения информации о второгой группе людей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTwoGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.TwoGroup());
        }
        /// <summary>
        /// Метод для перехода на страницу заполнения информации о третьей группе людей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreeGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ThreeGroup());
        }

        /// <summary>
        /// Метод для перехода на страницу с подсчетом количества непрямых конактов между первой и третьей группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResultGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.NumberContatc());
        }

        /// <summary>
        /// Метд для перехода на моделирования процесса распространения инфекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelingProcess(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ModelingProcess());
        }
        /// <summary>
        /// Метод для перехода на страницу заполнения информации о первой группе людей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOneGroup(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.OneGroup());
        }
        /// <summary>
        /// Метод для заполенение информации файла для дальнейшего его взаимодействия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLoaded(object sender, RoutedEventArgs e)
        {
            Models.InformationGroup informationGroup = new Models.InformationGroup(Path);

            informationGroup.CreateFileGroup();
        }

        /// <summary>
        /// Метод для вызова справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpravka(object sender, RoutedEventArgs e)
        {
            new Spravka().Show();
        }
        
        /// <summary>
        /// Метод для возрващения к меню регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit(object sender, RoutedEventArgs e)
        {
            closewin();
        }
    }
}
