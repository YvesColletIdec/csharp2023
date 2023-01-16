// break; continue;

int a = 1;
int b = 8;
while (a < 10)
{
    if (a < b)
    {
        Console.WriteLine("plus petit");
        a++;
        continue;
    }
    if (a > b)
    {
        Console.WriteLine("plus grand");
        a++;
        continue;
    }
    if (a == b)
    {
        Console.WriteLine("egal");
        a++;
        continue;
    }
    if (a != b)
    {
        Console.WriteLine("différent");
        a++;
        continue;
    }
    
    Console.WriteLine("toto");
}
Console.WriteLine("fin");