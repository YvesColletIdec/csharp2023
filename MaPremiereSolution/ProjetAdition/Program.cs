//VAR
int b = 0, a = 0;
Console.WriteLine("Veuillez saisir le 1er nombre");
//a = int.Parse(Console.ReadLine());
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Veuillez saisir le 2ème nombre");
b = int.Parse(Console.ReadLine());
Console.WriteLine("la somme de " + a + " + " + b + " est de " + (a + b));
Console.WriteLine($"la somme de {a} + {b} est de {(a + b)}");
Console.ReadLine();