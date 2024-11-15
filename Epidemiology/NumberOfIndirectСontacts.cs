using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epidemiology
{
    /// <summary>
    /// Рассчитывает количество непрямых контактов первой и третьей группы в виде матрицы второго порядка, а также моделирует процесс распоространения инфекции на учатске кожи 
    /// </summary>
    public class NumberOfIndirectСontacts
    {
        private Random rnd;

        private double Chance = 0.55;
        /// <summary>
        /// Метод возвращает количество непрямых конактов второго порядка
        /// </summary>
        /// <param name="CountOneGroup"></param>
        /// <param name="CountTwoGroup"></param>
        /// <param name="CountThreeGroup"></param>
        /// <returns></returns>
        public int CountContacts(int CountOneGroup, int CountTwoGroup, int CountThreeGroup)
        {
            rnd = new Random();

            int[,] MatrixA = new int[CountOneGroup, CountTwoGroup];

            int[,] MatrixB = new int[CountTwoGroup, CountThreeGroup];

            int[,] MatrixC = new int[CountOneGroup, CountThreeGroup];

            int CountInvalid;

            while (true)
            {
                CountInvalid = 0;

                for (int i = 0; i < CountOneGroup; i++)
                {
                    for (int j = 0; j < CountTwoGroup; j++)
                    {
                        int randomChance = rnd.Next(51, 59);
                        double chanceInvalid = randomChance * 0.01;
                        if (Chance <= chanceInvalid)
                        {
                            MatrixA[i, j] = 1;
                        }
                    }
                }

                for (int i = 0; i < CountTwoGroup; i++)
                {
                    for (int j = 0; j < CountThreeGroup; j++)
                    {
                        int randomChance = rnd.Next(51, 59);

                        double chanceInvalid = randomChance * 0.01;
                        if (Chance <= chanceInvalid)
                        {
                            MatrixB[i, j] = 1;
                        }
                    }
                }

                for (int i = 0; i < CountOneGroup; i++)
                {
                    for (int j = 0; j < CountThreeGroup; j++)
                    {
                        for (int k = 0; k < CountTwoGroup; k++)
                        {
                            MatrixC[i, j] += MatrixA[i, k] * MatrixB[k, j];
                        }
                    }
                }

                for (int i = 0; i < CountOneGroup; i++)
                {
                    for (int j = 0; j < CountThreeGroup; j++)
                    {
                        if (MatrixC[i, j] >= 2)
                        {
                            CountInvalid++;
                        }
                    }
                }

                if (CountInvalid > 0)
                {
                    break;
                }
            }
            return CountInvalid;
        }
    }
}
