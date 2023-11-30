using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Инфекция_не_пройдет
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void F1Shortcut1(object sender, ExecutedRoutedEventArgs e)
        {
            Spravka MySpravka = new Spravka();
            MySpravka.Show();
        }

        private UserData _userData;

        private InformationIO _informationIO;

        private readonly string Path = $"{Environment.CurrentDirectory}\\UserData.txt";

        private List<UserData> _userDatas;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReg(object sender, RoutedEventArgs e)
        {
            new WinReg().Show();
            Close();
        }

        private void btnComeIn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) & string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль");
            }
            else if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Введите логин");
            }
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Введите пароль");
            }
            else
            {
                _informationIO = new InformationIO(Path);

                _userDatas = new List<UserData>();

                try
                {
                    _userDatas = _informationIO.LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }

                string login = tbLogin.Text.Replace(" ", "");

                string password = tbPassword.Text.Replace(" ", "");

                _userData = new UserData(login, password);

                for (int i = 0; i < _userDatas.Count; i++)
                {
                    if (_userDatas[i].UserLogin == _userData.UserLogin && _userDatas[i].UserPassword == password)
                    {
                        new MainMenuWin().Show();
                        Close();
                    }

                    if (_userDatas[i].UserLogin == _userData.UserLogin && _userDatas[i].UserPassword != password)
                    {
                        MessageBox.Show("Пароль был введен не правильно");
                    }
                }

                string[] InfoUsers = new string[_userDatas.Count];

                for (int j = 0; j < _userDatas.Count; j++)
                {
                    InfoUsers[j] = _userDatas[j].UserLogin;
                }

                bool isExists = false;

                for (int k = 0; k < InfoUsers.Length; k++)
                {
                    if (InfoUsers[k] == _userData.UserLogin)
                    {
                        isExists = true;
                    }
                }

                if (!isExists)
                {
                    MessageBox.Show($"Пользователя с логином {_userData.UserLogin} не существует");
                }
            }
        }

        private void btnWinPasswordRecovery(object sender, RoutedEventArgs e) // Метод для восстановления пароля
        {
            new WinPasswordRecovery().Show();
            Close();
        }

    }
}
