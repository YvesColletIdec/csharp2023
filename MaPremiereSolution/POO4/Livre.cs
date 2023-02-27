using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO4
{
    internal class Livre
    {
        public string Titre { get; set; }
        public int Annee { get; set; }
        //encapsulation
        public List<Page> Pages { get; set; }
        public Livre() {
            Pages = new List<Page>();
        }
    }
}
