using System.Runtime.CompilerServices;

namespace POO1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.GenererEleves();
            //Eleve x;
            //x = new Eleve();
            //x.prenom = "toto";
            //x.nom = "Bolomay";
            //x.age = 32;

            //Eleve y = new Eleve();
            //y.age = 34;
            //x.age = y.age;

            //y = x;

            //Eleve z = x;

            //for (int i = 0; i< 101; i++)
            //{
            //    Eleve a = new Eleve();
            //}
        }

        public static void GenererEleves()
        {
            string chemin = @"c:\users/yves/onedrive\\bureau/eleve.txt";
            string[] lignes = File.ReadAllLines(chemin);
            List<Eleve> listeEleves = new List<Eleve>();
            List<string> listeDeNoms = new List<string>();
            foreach (string ligne in lignes)
            {
                Eleve a = new Eleve(ligne, ";");
                listeEleves.Add(a);
            }

            listeEleves.ForEach(e => listeDeNoms.Add(e.nom));

            //afficher tous les élèves de ma liste
            //foreach(Eleve b in listeEleves)
            //{
            //    Console.WriteLine($"Prénom : {b.prenom}, Nom : {b.nom}, Age : {b.age}");
            //}
            Console.WriteLine($"nombre d'élèves : {listeEleves.Count}");
            string cheminDestination = @"c:\users/yves/onedrive\\bureau/eleve2.txt";
            File.WriteAllLines(cheminDestination, listeDeNoms);
            Eleve el = listeEleves[1];
            listeEleves = null;
        }
    }
}