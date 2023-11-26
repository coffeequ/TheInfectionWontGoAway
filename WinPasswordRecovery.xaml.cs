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
using System.Windows.Shapes;
using Инфекция_не_пройдет.Models;

namespace Инфекция_не_пройдет
{
    /// <summary>
    /// Логика взаимодействия для WinPasswordRecovery.xaml
    /// </summary>
    public partial class WinPasswordRecovery : Window
    {
        public void F1Shortcut1(object sender, ExecutedRoutedEventArgs e)
        {
            Spravka MySpravka = new Spravka();
            MySpravka.Show();
        }

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

        private void ButtonSwitchPassword(object sender, RoutedEventArgs e)
        {
            string login = tblogin.Text;

            string password = tbPassword.Password;

            string passwodCorrect = tbCurrectPassword.Password;

            _informationIO = new InformationIO(Path);

            List<UserData> userDatas = _informationIO.LoadData();

            if (password != passwodCorrect)
            {
                MessageBox.Show("Ошибка пароли не совпадают");
            }
            else if (userDatas.Count == 0)
            {
                MessageBox.Show($"Пользователя с логином {login} не существует");
            }
            else
            {
                _userData = new UserData(login, password);

                string allLogin = "";

                for (int i = 0; i < userDatas.Count; i++)
                {
                    allLogin += userDatas[i].UserLogin;
                    allLogin += "_";
                }

                for (int i = 0; i < userDatas.Count; i++)
                {
                    if (!Regex.IsMatch(allLogin, _userData.UserLogin))
                    {
                        MessageBox.Show($"Пользователя с логином {_userData.UserLogin} не существует");
                        break;
                    }
                    else if (userDatas[i].UserLogin == _userData.UserLogin)
                    {
                        if (userDatas[i].UserPassword == _userData.UserPassword)
                        {
                            MessageBox.Show("Пароль не должен быть похож на старый");
                            break;
                        }
                        else
                        {
                            userDatas[i] = _userData;
                            _informationIO.SaveData(userDatas);
                            MessageBox.Show("Пароль был обновлен");
                            new MainWindow().Show();
                            Close();
                            break;
                        }
                    }
                }
            }

            
        }
    }
}
