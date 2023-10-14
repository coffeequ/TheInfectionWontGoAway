using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Инфекция_не_пройдет.Models
{
    class InformationIO
    {
        private readonly string Path;

        public InformationIO(string Path)
        {
            this.Path = Path;
        }

        public List<UserData> LoadData()
        {
            List<UserData> userDatas = new List<UserData>();

            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string[] InfoFile = sr.ReadToEnd().Split(new char[] {'\n'});

                    for (int i = 0; i < InfoFile.Length; i++)
                    {
                        userDatas.Add(new UserData(InfoFile[i].Split(new char[] {','})));
                    }
                }
                return userDatas;
            }

            File.CreateText(Path).Dispose();

            return new List<UserData>();
        }

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
