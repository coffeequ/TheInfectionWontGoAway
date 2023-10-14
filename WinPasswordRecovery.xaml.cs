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
using Инфекция_не_пройдет.Models;

namespace Инфекция_не_пройдет
{
    /// <summary>
    /// Логика взаимодействия для WinPasswordRecovery.xaml
    /// </summary>
    public partial class WinPasswordRecovery : Window
    {
        private UserData _userData;

        private InformationIO _informationIO;

        private readonly string Path = $"{Environment.CurrentDirectory}\\UserData.txt";

        public WinPasswordRecovery()
        {
            InitializeComponent();
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSwitchPassword(object sender, RoutedEventArgs e)
        {
            string login = tblogin.Text;

            string passwod = tbPassword.Password;

            string passwodCorrect = tbCurrectPassword.Password;

            _informationIO = new InformationIO(Path);

            List<UserData> userDatas = _informationIO.LoadData();

            for (int i = 0; i < userDatas.Count; i++)
            {

            }

        }
    }
}
