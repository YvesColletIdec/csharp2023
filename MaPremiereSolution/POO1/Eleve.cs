using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    public class Eleve
    {
        public string nom;
        public string prenom;
        public int age;

        public Eleve(string ligne, string separateur)
        {
            string[] donnees = ligne.Split(separateur);
            prenom = donnees[0];
            nom = donnees[1];
            age = int.Parse(donnees[2]);
        }
    }
}
