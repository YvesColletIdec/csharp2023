using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal class Poireau : Legume
    {
        public int Taille { get; set; }

        public override void Pousser()
        {
            Console.WriteLine("youpie je pousse");
        }

        public override void Chanter()
        {
            Console.WriteLine(  "lolololo");
        }
    }
}
