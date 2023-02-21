using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2
{
    public class Moto
    {
        private string _couleur;

        public string Couleur{
            set { 
                if (value == "rouge")
                    _couleur = "bleu";
                else
                    _couleur = value;
            }
            get { return _couleur == "rouge" ? "vert" : _couleur; }
            }

        //propfull
        private int _vitesseMax;

        public int VitesseMax
        {
            get { return _vitesseMax; }
            set { _vitesseMax = value;
                this.GetType();
            }
        }

        //prop
        public bool Is125cm3 { get; set; }
        public string Toto { get; set; }
        public int MyProperty { get; set; }

    }
}
