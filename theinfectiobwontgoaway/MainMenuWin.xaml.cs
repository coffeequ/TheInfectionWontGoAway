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
using System.Windows.Shapes;

namespace Инфекция_не_пройдет
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWin.xaml
    /// </summary>
    public partial class MainMenuWin : Window
    {
        public MainMenuWin()
        {
            InitializeComponent();
            Pages.MainMenu.closewin += MainMenu_closewin;
            MyFrame.NavigationService.Navigate(new Pages.MainMenu());
        }

        /// <summary>
        /// Метод для перехода на окно с авторизацией пользователя
        /// </summary>
        private void MainMenu_closewin()
        {
            new MainWindow().Show();
            Close();
        }

        /// <summary>
        /// Метод для вызова справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void F1Shortcut1(object sender, ExecutedRoutedEventArgs e)
        {
            Spravka MySpravka = new Spravka();
            MySpravka.Show();
        }
    }
}
