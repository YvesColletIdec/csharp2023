using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2
{
    public class MaListe
    {
        public static void ExempleDeListe()
        {
            string[] strings = { "salut", "hello", "coucou", "adieu" };
            string x = "af, asdfasdf,sadf asdf,sadf, asdf,a sd,f asd,f,asdfsa, d";
            List<string> y = x.Split(",").ToList();
            foreach (string s in y)
            {
                Console.WriteLine(s);
            }
            List<string> list = strings.ToList();
            list = new List<string>() { "", "", "" };
            list.Add("nouvel élément");
            list.Remove("hello");
            list.Sort();
            Console.WriteLine(list.Count);
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}
