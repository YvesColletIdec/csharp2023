using Coucou;
namespace Salut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b = 0;
            Console.WriteLine("Veuillez saisir la valeur 1");
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Veuillez saisir la valeur 2");
            int.TryParse(Console.ReadLine(), out b);
            Calcul.CalculSomme(a, b);
            int somme = Calcul.RetourneSomme(a, b);
            Console.WriteLine(somme);
        }

        static void Go()
        {

        }

        


    }
}