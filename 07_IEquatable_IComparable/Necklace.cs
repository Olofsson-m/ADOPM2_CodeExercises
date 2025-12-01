using System;
using System.Drawing;
using Seido.Utilities.SeedGenerator;

namespace _07_IEquatable_IComparable
{
    public class Necklace
    {
        public List<Pearl> ListOfPearls { get; set; } = new List<Pearl>();
        public string Name { get; set; }

        public override string ToString()
        {
            string sRet = $"\n{Name}:";
            foreach (var item in ListOfPearls)
            {
                sRet += $"\n{item.ToString()}";
            }
            return sRet;
        }

        public Necklace(string name)
        {
            Name = name;
        }
        public Necklace(int nrPearls, string name)
        {
            Name = name;
            var rnd = new SeedGenerator();
            for (int i = 0; i < nrPearls; i++)
            {
                ListOfPearls.Add(new Pearl(rnd));
            }
        }
        public Necklace(string name, Pearl _p1, Pearl _p2)
        {
            Name = name;
            ListOfPearls.Add(_p1);
            ListOfPearls.Add(_p2);
        }
        public Necklace(Necklace org)
        {
            Name = org.Name;
            //Referrence copy
            //ListOfPearls = org.ListOfPearls;

            ListOfPearls = new List<Pearl>();
            for (int i = 0; i < org.ListOfPearls.Count; i++)
            {
                this.ListOfPearls.Add(new Pearl(org.ListOfPearls[i]));
            }
         
        }
    }
}

