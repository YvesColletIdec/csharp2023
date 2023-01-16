int a = 5;
int saisie = 0;
do
{
    Console.WriteLine("Veuillez saisir la valeur 5");

    if (!int.TryParse(Console.ReadLine(), out saisie))
    {
        Console.WriteLine("le format n'est pas correct");
    }
    
    
} while (saisie != a);