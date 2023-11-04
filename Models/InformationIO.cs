using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Инфекция_не_пройдет.Models
{
    /// <summary>
    /// Класс для вывода и ввода данных в лист
    /// </summary>
    class InformationIO
    {
        private readonly string Path;

        public InformationIO(string Path)
        {
            this.Path = Path;
        }

        /// <summary>
        /// Метод позволяет загружать данные в лист где будут хранится все пользователи. Если файла с пользователями нет, то создает новый, а если он есть берет из него все данные
        /// </summary>
        /// <returns></returns>
        public List<UserData> LoadData()
        {
            List<UserData> userDatas = new List<UserData>();

            bool fileExists = File.Exists(Path);

            if (fileExists)
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string tempSr = sr.ReadToEnd();

                    if (tempSr == "")
                    {
                        sr.Close();

                        File.CreateText(Path).Dispose();
                        
                        return new List<UserData>();
                    }
                    else
                    {
                        string[] InfoFile = tempSr.Split(new char[] { '\n' });

                        int lengthInfoFile = InfoFile.Length - 1;

                        string[] AllInformation = new string[lengthInfoFile];

                        for (int j = 0; j < InfoFile.Length - 1; j++)
                        {
                            AllInformation[j] = InfoFile[j];
                        }

                        for (int i = 0; i < AllInformation.Length; i++)
                        {
                            AllInformation[i] = AllInformation[i].Remove(AllInformation[i].Length - 1);
                            AllInformation[i] = AllInformation[i].Replace(" ", "");
                            AllInformation[i] = AllInformation[i].Replace("Login:", "");
                            AllInformation[i] = AllInformation[i].Replace("password:", "");
                        }

                        for (int i = 0; i < AllInformation.Length; i++)
                        {
                             userDatas.Add(new UserData(AllInformation[i].Split(new char[] { ',' })));
                        }
                    }
                }
                return userDatas;
            }
            else
            {
                File.CreateText(Path).Dispose();

                return new List<UserData>();
            }
        }


        /// <summary>
        /// Метод для сохранения данных в файл
        /// </summary>
        /// <param name="userDatas"></param>
        public void SaveData(List<UserData> userDatas)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                for (int i = 0; i < userDatas.Count; i++)
                {
                    sw.WriteLine(userDatas[i].ConclisionInf());
                }
            }
        }

        //public List<int> LoadDataGroup(string Path)
        //{
        //    bool fileExist = File.Exists(Path);

        //    int[] MyArray = new int[10];
        //    MyArray.Distinct

        //    using (StreamReader sr = new StreamReader(Path))
        //    {
        //        byte CountGroup = 3;

        //        List<int> Groups = new List<int>();

        //        for (int i = 0; i < CountGroup; i++)
        //        {
        //            Groups.Add(Convert.ToInt32(sr.ReadLine()));
        //        }

        //        return Groups;
        //    }
        //}

        ///// <summary>
        ///// Метод для сохрнанения информации об количествах людей в соотвествующих группах
        ///// </summary>
        ///// <param name="CountOneGroup"></param>
        ///// <param name="CountTwoGroup"></param>
        ///// <param name="CountThreeGroup"></param>
        //public void SaveDataGroup(int CountOneGroup, int CountTwoGroup, int CountThreeGroup, string Path)
        //{
        //    List<int> CountMenGroup = LoadDataGroup(Path);
            
        //    CountMenGroup = new List<int>();

        //    for (int i = 0; i < CountMenGroup.Count; i++)
        //    {
        //        if (i == 0)
        //        {
        //            if (CountMenGroup[i] == 0)
        //            {
        //                CountMenGroup[i] = CountOneGroup;
        //            }
        //        }
        //        if (i == 1)
        //        {
        //            if (CountMenGroup[i] == 0)
        //            {
        //                CountMenGroup[i] = CountTwoGroup;
        //            }
        //        }
        //        if (i == 2)
        //        {
        //            if (CountMenGroup[i] == 0)
        //            {
        //                CountMenGroup[i] = CountThreeGroup;
        //            }
        //        }
        //    }

        //    using (StreamWriter sw = new StreamWriter(Path))
        //    {
        //        for (int i = 0; i < CountMenGroup.Count; i++)
        //        {
        //            sw.WriteLine(CountMenGroup[i]);
        //        }
        //    }
        //}
    }
}
