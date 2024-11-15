using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epidemiology
{
    /// <summary>
    /// Класс для моделирования процесса распространения инфекции на участке кожи
    /// </summary>
    public class GamesEngine
    {
        //Матрица клеток для хранения информации о каждой из них
        public Kletka[,] kletkas;

        //Объект класса Random служащий для генерации шанса заражения клетки.
        private Random rnd;

        //Свойство предназаченное для хранения количества строк
        public int rows { get; set; }

        //Свойство предназначенное для хранения количества столбцов
        public int columns { get; set; }

        //Шанс заражения соседней клетки
        private readonly double chanche = 0.50;
        
        public GamesEngine(int columns, int rows)
        {
            this.rows = rows;

            this.columns = columns;

            kletkas = new Kletka[columns, rows];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    kletkas[i, j] = new Kletka();
                }
            }

            int centerY = rows / 2;
            int centerX = columns / 2;

            kletkas[centerX, centerY].State = KletkaState.Infected;
        }

        /// <summary>
        /// Асинхронный метод для генерации следующего поколения клеток, в качестве параметра принимает состояние остановки игры
        /// </summary>
        /// <param name="isStopGame"></param>
        public async void AsyncNextGeneraionInfection(bool isStopGame)
        {
            Kletka[,] NewKletkas = new Kletka[columns, rows];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    NewKletkas[i, j] = kletkas[i, j];
                }
            }

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int CountNeighboursInfection = CountsNeighboursInfection(x, y);

                    Kletka hasKletka = kletkas[x, y];

                    if (!isStopGame & hasKletka.State == KletkaState.Helthy && (CountNeighboursInfection >= 1 || 3 <= CountNeighboursInfection))
                    {
                        NewKletkas[x, y].SwapStatusInfectionToImmune();
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

        /// <summary>
        /// Метод подсчета количества соседних зараженных клеток, в качестве параметра принимает координаты клетки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CountsNeighboursInfection(int x, int y)
        {
            int count = 0;

            rnd = new Random();

            double rndValue;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    double temp = rnd.Next(48, 52);

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

        /// <summary>
        /// Метод для обеспечение инкапсуляции массива клеток
        /// </summary>
        /// <returns></returns>
        public Kletka[,] GetCurrentGeneration()
        {
            var result = new Kletka[columns, rows];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = kletkas[i, j];
                }
            }

            return result;
        }
    }
}
