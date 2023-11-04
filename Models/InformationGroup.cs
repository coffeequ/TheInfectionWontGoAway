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
        private readonly string Path;

        public InformationGroup(string Path)
        {
            this.Path = Path;
        }

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
    }
}
