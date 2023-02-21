using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2
{
    public class Humain
    {
        private bool _isFemme = false;

        public string Nom { get; set; }

        public Humain(string genre)
        {
            if (genre == "H")
                _isFemme = false;
            else
                _isFemme = true;
        }

        public string Presentation()
        {
            string genre = _isFemme ? "une femme" : "un homme";
            return $"je m'appelle {Nom} et je suis {genre}";
            //"je m'appelle Robert et je suis un homme"
        }
    }
}
