Console.WriteLine(args.Length);
//déclaration du tableau et instanciation de celui-ci
string[] tab = new string[10];
for(int i = 0; i < tab.Length;i++)
{
    tab[i] = "-";
    //string y = tab[i];
}
//1:-
//5:-
int x = 1;
string y = "-";
foreach(string s in tab)
{
    Console.WriteLine($"{++x}:{s}");
}

string[] tab2 = {"M.", "Mme.", "Mlle" };