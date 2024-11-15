using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Инфекция_не_пройдет.Models
{
    class InformationGroup
    {
        // Поле для указания пути к файлу
        private readonly string Path;

        public InformationGroup(string Path)
        {
            this.Path = Path;
        }
        /// <summary>
        /// Метод для создания групп людей
        /// </summary>
        public void CreateFileGroup()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Dispose();
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        sw.WriteLine("0");
                    }
                }
            }
        }

        /// <summary>
        /// Метод для загрузки информации о группах
        /// </summary>
        /// <returns></returns>
        public List<int> LoadGroup()
        {
            List<int> ListGroup = new List<int>();

            using (StreamReader sr = new StreamReader(Path))
            {
                for (int i = 0; i < 3; i++)
                {
                    ListGroup.Add(Convert.ToInt32(sr.ReadLine()));
                }
            }
            return ListGroup;
        }

        /// <summary>
        /// Метод для сохранения информации об определнной группе людей
        /// </summary>
        /// <param name="ValueForSave"></param>
        /// <param name="Position"></param>
        public void SaveGroup(int ValueForSave, int Position)
        {
            int[] CountMenGroups = new int[3];

            using (StreamReader sr = new StreamReader(Path))
            {
                for (int i = 0; i < CountMenGroups.Length; i++)
                {
                    CountMenGroups[i] = Convert.ToInt32(sr.ReadLine());
                }
            }

            using (StreamWriter sw = new StreamWriter(Path))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == Position)
                    {
                        CountMenGroups[i] = ValueForSave;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    sw.WriteLine(CountMenGroups[i]);
                }
            }
        }

        /// <summary>
        /// Метод для сохранения массива групп
        /// </summary>
        /// <param name="Groups"></param>
        public void SaveResult(List<int> Groups)
        {
            using (StreamWriter sw = new StreamWriter("ResultNumberContact.txt"))
            {
                for (int i = 0; i < Groups.Count; i++)
                {
                    if (i == 0)
                    {
                        sw.WriteLine($"В первой группе: {Groups[i]}");
                    }
                    if (i == 1)
                    {
                        sw.WriteLine($"Во второй группе: {Groups[i]}");
                    }
                    if (i == 2)
                    {
                        sw.WriteLine($"В третьей группе: {Groups[i]}");
                    }
                    if (i == 3)
                    {
                        sw.WriteLine($"Количество непрямых контактов: {Groups[i]}");
                    }
                }
            }
        }
    }
}
