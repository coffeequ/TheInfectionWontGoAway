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
    /// Логика взаимодействия для WinReg.xaml
    /// </summary>
    public partial class WinReg : Window
    {
        public void F1Shortcut1(object sender, ExecutedRoutedEventArgs e)
        {
            Spravka MySpravka = new Spravka();
            MySpravka.Show();
        }

        private Models.UserData _userData;

        private InformationIO _informationIO;

        private readonly string Path = $"{Environment.CurrentDirectory}\\UserData.txt";

        public WinReg()
        {
            InitializeComponent();
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void ButtonReg(object sender, RoutedEventArgs e)
        {
            string login = tblogin.Text.Trim();

            string password = tbPassword.Password.Trim();

            _informationIO = new InformationIO(Path);

            _userData = new UserData(login, password);

            List<UserData> userDatas = _informationIO.LoadData();

            if (userDatas.Count == 0)
            {
                userDatas.Add(_userData);
                MessageBox.Show($"Пользователь был добавлен. Запомните ваш логин {_userData.UserLogin}");
                _informationIO.SaveData(userDatas);
                new MainWindow().Show();
                Close();
            }
            else
            {
                string InfoUsers = "";

                for (int j = 0; j < userDatas.Count; j++)
                {
                    InfoUsers += userDatas[j].UserLogin + '_';
                }

                if (Regex.IsMatch(InfoUsers, _userData.UserLogin))
                {
                    MessageBox.Show($"Пользователя с логином {_userData.UserLogin} уже существует, пожалуйста придумайте новый логин");
                }
                else
                {
                    userDatas.Add(_userData);
                    MessageBox.Show("Успешная регистрация");
                    _informationIO.SaveData(userDatas);
                    new MainWindow().Show();
                    Close();
                }
            }
        }
    }
}
