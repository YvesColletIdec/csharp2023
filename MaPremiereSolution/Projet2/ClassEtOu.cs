using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2
{
    public class ClassEtOu
    {

        public static bool Trou()
        {
            return true;
        }
        public static void TestEtOu()
        {
            int a = 1;
            int b = 3;
            if (a == 2 & b == 3)
            {
                Console.WriteLine("vrai");
            }
            if (a == 2 || b == 3 && b + a == 3 | a < b & b == a & ClassEtOu.Trou())
            {
                Console.WriteLine("vrai");
            }
        }
        
    }
}
