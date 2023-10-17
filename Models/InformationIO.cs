using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

            var fileExists = File.Exists(Path);

            if (fileExists)
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string tempSr = sr.ReadToEnd();

                    sr.Close();

                    if (tempSr == "")
                    {
                        File.CreateText(Path).Dispose();
                        
                        return new List<UserData>();
                    }
                    else
                    {
                        string[] InfoFile = sr.ReadToEnd().Split(new char[] { '\n' });

                        for (int i = 0; i < InfoFile.Length; i++)
                        {
                             userDatas.Add(new UserData(InfoFile[i].Split(new char[] { ',' })));
                        }
                    }
                }
                return userDatas;
            }

            File.CreateText(Path).Dispose();

            return new List<UserData>();
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
    }
}
