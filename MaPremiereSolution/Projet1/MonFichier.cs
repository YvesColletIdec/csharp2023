using nameprojet2;
using Projet2;

namespace nameprojet1
{
    public class MonFichier
    {
        static void Main(string[] args)
        {
            MaListe.ExempleDeListe();
            List<int> listAEnvoyer = null;
            MaListe.Jeveuxuneliste(listAEnvoyer);
            try
            {
                Console.WriteLine("ouverture d'un fichier texte");
                Console.WriteLine("DEBUT");
                Console.WriteLine(MaClasse.Division(7, 0));
                Console.WriteLine("FIN");
            }
            catch (Exception erreur)
            {
                Console.WriteLine(erreur.Message);
            } finally
            {
                Console.WriteLine("fermeture d'un fichier texte");
            }
            Console.WriteLine("toto");
            string contenu = File.ReadAllText(@"C:/Users/Yves/OneDrive/Bureau/erreur.txt");
            //Console.WriteLine(contenu);

            
        }
    }
}