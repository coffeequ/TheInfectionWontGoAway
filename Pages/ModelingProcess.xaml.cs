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
using TheInfectionWontGoAway;

namespace Инфекция_не_пройдет.Pages
{
    /// <summary>
    /// Логика взаимодействия для ModelingProcess.xaml
    /// </summary>
    public partial class ModelingProcess : Page
    {
        GamesEngine modelingProcessInf;

        DispatcherTimer timerInfection;

        private const double chanche = 0.50;

        int rows;

        int columns;

        private bool isStopGame = true;

        Random rnd;

        private int KletkaSize = 20;

        public ModelingProcess()
        {
            InitializeComponent();
        }

        private void BtnStartGame(object sender, RoutedEventArgs e)
        {
            isStopGame = true;

            if (!string.IsNullOrEmpty(tbHeight.Text) & !string.IsNullOrEmpty(tbWidth.Text))
            {
                try
                {
                    rows = int.Parse(tbHeight.Text);
                    columns = int.Parse(tbWidth.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (rows % 2 == 0 || rows == 0 & columns % 2 == 0 || columns == 0)
                {
                    MessageBox.Show("Поля должны быть нечетными");
                    return;
                }

                if (columns > 0 & columns < 32 & rows > 0 & rows < 32)
                {
                    modelingProcessInf = new GamesEngine(columns, rows);

                    timerInfection.Interval = TimeSpan.FromMilliseconds(1000);
                    timerInfection.Start();
                    timerInfection.Tick += Timer_Tick;
                }
                else
                {
                    MessageBox.Show("Введите значения, которые будут больше 0 и меньше 32");
                }
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SeeProcess();
        }

        private void tbClose(object sender, RoutedEventArgs e)
        {
            timerInfection.Stop();
            NavigationService.Navigate(new Pages.MainMenu());
        }

        public void SeeProcess()
        {
            var Kletkas = modelingProcessInf.GetCurrentGeneration();

            canvasGame.Children.Clear();

            Rectangle rectangle;

            var conveter = new System.Windows.Media.BrushConverter();

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

            if (timerInfection.IsEnabled)
            {
                NextGeneraionInfection(modelingProcessInf.kletkas);
            }
        }

        public async void NextGeneraionInfection(Kletka[,] kletkas)
        {
            Kletka[,] NewKletkas = new Kletka[columns, rows];

            int countInfAll = 0;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (kletkas[i, j].State == KletkaState.Infected)
                    {
                        countInfAll++;
                    }
                    NewKletkas[i, j] = kletkas[i, j];
                }
            }

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int CountNeighboursInfection = CountsNeighboursInfection(x, y, kletkas);

                    Kletka hasKletka = kletkas[x, y];

                    if (isStopGame & hasKletka.State == KletkaState.Helthy && (CountNeighboursInfection >= 1 || 3 <= CountNeighboursInfection))
                    {
                        await Task.Delay(200);
                        NewKletkas[x, y].InfectionUpdate();
                    }
                    else if (hasKletka.State == KletkaState.Infected)
                    {
                        NewKletkas[x, y].SwapStatusInfectionToImmune();
                    }

                    else if (hasKletka.State == KletkaState.Immune)
                    {
                        NewKletkas[x, y].SwapStatusImmuneToHealthy();
                    }
                }
            }

            kletkas = NewKletkas;
        }

        private int CountsNeighboursInfection(int x, int y, Kletka[,] kletkas)
        {
            int count = 0;

            rnd = new Random();

            double rndValue;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    double temp = rnd.Next(48, 51);

                    rndValue = temp * 0.01;

                    if (chanche == rndValue)
                    {
                        int column = (x + i + columns) % columns;

                        int row = (y + j + rows) % rows;

                        bool isSelfChecking = column == x & row == y;

                        var hasKletka = new Kletka();

                        hasKletka = kletkas[column, row];

                        if (hasKletka.State == KletkaState.Infected & !isSelfChecking)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return count;
        }

        private void BtnStopGame(object sender, RoutedEventArgs e)
        {
            isStopGame = false;
        }

        private void gridLoaded(object sender, RoutedEventArgs e)
        {
            timerInfection = new DispatcherTimer();
        }
    }
}
