namespace POO3
{
    internal class Program
    {
        //polymorphisme
        static void Main(string[] args)
        {
            Science physique = new Physique();
            //physique.TypePhysique = "quantique";
            physique.NomEnLatin = "physicus";
            physique.NomDesExperiences = "Mes expériences";
            if (physique is Physique)
            {
                Console.WriteLine("c'est physique");
            } else
            {
                Console.WriteLine("autre");
            }
            Chimie c = new Chimie();
            Science c1 = new Science();
            Science c2 = new Chimie();
            //Chimie c3 = new Physique();

            //on demande à l'utilisateur de saisir c -> chimie ou p -> physique
            Science s = null;
            string saisieUtilisateur = "c";
            if (saisieUtilisateur == "c")
            {
                s = new Chimie();
                s.NomDesExperiences = "toto";
                //1.
                Chimie s2 = s as Chimie;
                Console.WriteLine(s2.NomDesExperiences);
                //2.
                ((Chimie)s).CouleurDuProduit = "jaune";
                Console.WriteLine(s is Chimie);
            } else if (saisieUtilisateur != "p")
            {
                s = new Physique();
            } else
            {
                Console.WriteLine("ERREUR");
            }
        }
    }
}