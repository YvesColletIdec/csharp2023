using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal abstract class Legume
    {
        public string Nom { get; set; }
        public string Couleur { get; set; }

        public abstract void Pousser();

        public virtual void Chanter()
        {
            Console.WriteLine(  "lalaalalal");
        }
    }
}
