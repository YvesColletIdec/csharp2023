using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticNonStatic
{
    public class Humain
    {
        public static int nombreBras = 2;
        public string nom;

        public static void FaitesAAAAHHHHH()
        {
            Console.WriteLine("AAAAHHHHH");
        }

        public void DisTonNom()
        {
            Console.WriteLine($"je m'appelle {nom}");
        }

        //public Humain()
        //{
        //    Console.WriteLine("youpie un nouvel humain");
        //}

        public Humain(string unNom)
        {
            nom = unNom;
        }

        public Humain(string unprenom, string unnom) { }

    }
}
