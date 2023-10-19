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

            string password = tbPassword.Password;

            string passwodCorrect = tbCurrectPassword.Password;

            _informationIO = new InformationIO(Path);

            try
            {
                if (password != passwodCorrect)
                {
                    throw new Exception("Ошибка. Пароли не совпадают");
                }

                _userData = new UserData(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List<UserData> userDatas = _informationIO.LoadData();

            int userIndex = 0;

            for (int i = 0; i < userDatas.Count; i++)
            {
                if (userDatas[i].UserLogin != login)
                {
                    userDatas.Add(_userData);
                    MessageBox.Show("Пароль был обновлён!");
                    _informationIO.SaveData(userDatas);
                    new MainWindow().Show();
                    Close();
                    break;
                }
                else
                {
                    userIndex = i;

                    if (userDatas[userIndex].UserPassword == password)
                    {
                        MessageBox.Show("Пароль не должен быть похож на старый");
                    }
                    else
                    {
                        userDatas[userIndex].UserPassword = passwodCorrect;
                        _informationIO.SaveData(userDatas);
                        new MainWindow().Show();
                        Close();
                    }
                }
            }

            
        }
    }
}
