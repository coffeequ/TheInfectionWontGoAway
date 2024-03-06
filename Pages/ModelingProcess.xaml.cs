using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Epidemiology;

namespace Инфекция_не_пройдет.Pages
{
    //***********************************************************************************************
    //* Название программы: "Библиотека "Эпидемиология""                                            *
    //*                                                                                             *
    //* Назначение программы: Бибилиотека предназначена для моделирования процесса распространения. *
    //*                                                                                             *
    //* Разработчик: студент группы ПР-330/б Пугач С.Е.                                             *
    //*                                                                                             *
    //* Версия: 1.0                                                                                 *
    //***********************************************************************************************

    /// <summary>
    /// Логика взаимодействия для ModelingProcess.xaml
    /// </summary>
    public partial class ModelingProcess : Page
    {
        // Класс для моделирования процесса распространения
        GamesEngine modelingProcessInf;

        // Класс для таймера
        DispatcherTimer timerInfection;

        // Количество строк
        int rows;

        // Количество столбцов
        int columns;

        // Запущена ли игра
        private bool isStopGame = false;

        // Размер клетки
        private int KletkaSize = 20;

        public ModelingProcess()
        {
            InitializeComponent();
        }

        //Метод для старта моделирования процесса распространения
        private void BtnStartGame(object sender, RoutedEventArgs e)
        {
            isStopGame = false;
            if (!string.IsNullOrEmpty(tbHeight.Text) & !string.IsNullOrEmpty(tbWidth.Text))
            {
                timerInfection.Stop();
                try
                {
                    rows = int.Parse(tbHeight.Text);
                    columns = int.Parse(tbWidth.Text);

                    if (columns <= 0 || columns >= 32)
                    {
                        throw new Exception("Количество столбцов должно быть больше 0 или меньше 32");
                    }
                    else if (rows <= 0 || rows >= 32)
                    {
                        throw new Exception("Количество строк должно быть больше 0 или меньше 32");
                    }

                    if (rows % 2 == 0 && rows >= 0)
                    {
                        throw new Exception("Значение количества строк должно быть нечетным");
                    }
                    else if (columns % 2 == 0 & columns >= 0)
                    {
                        throw new Exception("Зачение количества столбцов должно быть нечетным");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                modelingProcessInf = new GamesEngine(columns, rows);
                timerInfection.Interval = TimeSpan.FromMilliseconds(1000);
                timerInfection.Start();
                timerInfection.Tick += Timer_Tick;
                NameBtnStartGame.IsEnabled = false;
                NameBtnStopGame.IsEnabled = true;  
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
            }
        }

        //Метод таймера для визуализации процесса распространения
        private void Timer_Tick(object sender, EventArgs e)
        {
            modelingProcessInf.AsyncNextGeneraionInfection(isStopGame);
            SeeProcess();
        }

        //Метод для возврата назад в меню
        private void tbClose(object sender, RoutedEventArgs e)
        {
            timerInfection.Stop();
            NavigationService.Navigate(new Pages.MainMenu());
        }

        //Метод для визуализации клеток
        private void SeeProcess()
        {
            var Kletkas = modelingProcessInf.GetCurrentGeneration();

            canvasGame.Children.Clear();

            Rectangle rectangle;

            var conveter = new BrushConverter();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    rectangle = new Rectangle()
                    {
                        Width = KletkaSize,
                        Height = KletkaSize,
                        Stroke = Brushes.Black
                    };

                    Canvas.SetLeft(rectangle, j * KletkaSize);
                    Canvas.SetTop(rectangle, i * KletkaSize);

                    if (Kletkas[i, j].State == KletkaState.Helthy)
                    {
                        var brush = (Brush)conveter.ConvertFromString("#4fff48");

                        rectangle.Fill = brush;
                    }

                    if (Kletkas[i, j].State == KletkaState.Infected)
                    {
                        var brush = (Brush)conveter.ConvertFromString("#ff6657");

                        rectangle.Fill = brush;
                    }

                    if (Kletkas[i, j].State == KletkaState.Immune)
                    {
                        var brush = (Brush)conveter.ConvertFromString("#38b2ce");

                        rectangle.Fill = brush;
                    }
                    canvasGame.Children.Add(rectangle);
                }
            }
        }

        //Метод для остановки распространения
        private void BtnStopGame(object sender, RoutedEventArgs e)
        {
            isStopGame = true;
            NameBtnStartGame.IsEnabled = true;
            NameBtnStopGame.IsEnabled = false;
        }

        //Метод для выделения памяти под таймер и выключение кнопки "Остановить процесс"
        private void gridLoaded(object sender, RoutedEventArgs e)
        {
            timerInfection = new DispatcherTimer();
            NameBtnStopGame.IsEnabled = false;
        }
    }
}
