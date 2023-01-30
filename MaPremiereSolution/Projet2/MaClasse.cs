using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nameprojet2
{
    public class Toto
    {
        public static void Salut()
        {

        }

        public static void Coucou() { }
    }
    public class MaClasse
    {
        public static double Division(int a, int b)
        {
            try
            {
                return a / b;
            } catch(Exception e)
            {
                File.AppendAllText(@"C:/Users/Yves/OneDrive/Bureau/erreur.txt", $"{DateTime.Now} : {e.StackTrace}{Environment.NewLine}");
                throw e;
                
            }
            
        }


        static void Main(string[] args)
        {
            //ne pas utiliser
        }
    }
}
