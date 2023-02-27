namespace POO4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livre livre = new Livre();
            livre.Titre = "Mon Livre";
            livre.Annee = 2023;
            livre.Pages.Add(new Page() { Numero = 1, Texte = "AAA"});
            livre.Pages.Add(new Page() { Numero = 4, Texte = "DDD" });
            livre.Pages.Add(new Page() { Numero = 2, Texte = "BBB" });

            //changer le texte de la page 2 par "toto"
            foreach (Page p in livre.Pages)
            {
                if (p.Numero == 2)
                {
                    p.Texte = "toto";
                }
            }

            int numero = livre.Pages[1].Numero;

            Console.WriteLine(  numero);
        }
    }
}