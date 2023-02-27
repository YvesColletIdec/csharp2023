using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2
{
    public class Voiture : Vehicule
    {
        private string _marque;
        //en cm3
        private int _cylindree;

        private string _puissance;

        protected int Salut { get; set; }

        public Voiture()
        {
            this._aUnMoteur = true;
            _nom = "toto";
        }
        public string GetPuissance()
        {
            return _puissance;
        }

        public void SetMarque(string _marque)
        {
            this._marque = _marque;
        }

        public string GetMarque()
        {
            return this._marque;
        }

        public void SetCylindree(int cylindree)
        {
            if(cylindree >= 10000 || cylindree <=1000)
            {
                _cylindree = 2000;
            }
            else
            {
                _cylindree = cylindree;
            }
            if (_cylindree < 2500)
                _puissance = "nulle";
            else if (_cylindree >= 2500 && _cylindree < 4000)
                _puissance = "puissante";
            else
                _puissance = "super puissante";
        }

        public int GetCylindree()
        {
            return this._cylindree;
        }

        public string Description()
        {
            return this._marque + " " + this._cylindree;
        }
    }
}
