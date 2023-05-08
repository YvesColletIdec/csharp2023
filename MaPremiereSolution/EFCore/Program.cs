using EFCore.entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //oubli PK dans LigneFacture

            //1.?
            SqlServerContext context = new SqlServerContext();
            Article a = context.Articles.Include(ar => ar.Categorie).Include(lf => lf.LigneFactures).FirstOrDefault();
            Console.WriteLine(a.Categorie.Nom);

            //2.
            Client c = context.Clients.FirstOrDefault();
            Facture f = new Facture() { DateFacture = DateTime.Now, Client = c };
            context.Factures.Add(f);
            context.SaveChanges();
            Facture f2 = context.Factures.OrderByDescending(x => x.Id).FirstOrDefault();
            Console.WriteLine($"id = {f2.Id}, clientid = {f2.ClientId}, date = {f2.DateFacture}");

            //context.Articles.Include(a => a.Categorie).Select(x => x.Categorie.Nom).Distinct().ToList().ForEach(x => Console.WriteLine(x));

            //List<Article> listArticles = context.Articles.ToList();
            //foreach (Article article in listArticles)
            //{
            //    Categorie c = context.Categories.FirstOrDefault(cx => cx.Id == article.CategorieId);
            //}

            //List<Article> articles = context.Articles.Include(a => a.Categorie).ToList();
            //foreach (Article article in articles)
            //{
            //    Console.WriteLine(article?.Categorie?.Nom);
            //}

            //classe partial
            //List<Client> clients = context.Clients.ToList();
            //clients.ForEach(c => Console.WriteLine(c.Prenom_Nom));

            //suppression de données --> delete from categorie where id = 30
            //Categorie c = context.Categories.FirstOrDefault(cat => cat.Id == 30);
            //context.Categories.Remove(c);
            //context.SaveChanges();

            //mise à jour --> update categorie set nom = 'Développement' where id = 1
            //Categorie c = context.Categories.Where(cat => cat.Id == 1).FirstOrDefault();
            //Console.WriteLine($"Id : {c.Id} Nom : {c.Nom}");
            //c.Nom = "Développement";
            //context.SaveChanges();

            //insertion d'une nouvelle donnée --> insert into categorie values ('efcore', true)
            //for(int i = 1; i < 10; i++)
            //{
            //    Categorie c = new Categorie();
            //    if (i != 6)
            //        c.Nom = "efcore" + i;
            //    else
            //        c.Nom = null;
            //    c.Estactif = true;
            //    context.Categories.Add(c);

            //   // Console.WriteLine($"Id : {c.Id}");
            //}
            //context.SaveChanges();


            //select * from categorie
            //List<Categorie> listCategorie = context.Categories.ToList();
            //foreach(Categorie categorie in listCategorie)
            //{
            //    Console.WriteLine(  categorie.Nom);
            //}
        }
    }
}