using System.Threading.Channels;

namespace TestEfCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. ouvrir connexion à la base
            SqlServerContext connexion = new SqlServerContext();
            //2. select * from article
            List<Article> listeArticles = connexion.Articles.ToList();
            listeArticles.ForEach(a  => Console.WriteLine(a.Nom));
            //3. update article set nom = 'bonne soirée' where id = ?
            listeArticles[2].Nom = "Bonne soirée";
            connexion.SaveChanges();
        }
    }
}