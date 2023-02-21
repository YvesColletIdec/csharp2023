using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2
{
    public class VoitureElectrique : Voiture
    {

        public int TailleBatterie { get; }
        private string _toto;
        

        public VoitureElectrique(int tailleBatterie)
        {
            TailleBatterie = tailleBatterie;
        }

        public string NombreBatterie
        {
            get { return _toto; }
            set { _toto = value; }
        }

        public VoitureElectrique()
        {
            
        }
    }
}
