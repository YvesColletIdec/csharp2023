//condition si
int b = 34;
int a = 345;
a += 5; //350
a = b + (2 * a); //734
Console.WriteLine(a);
Console.WriteLine(b);
//a < 10 | a > 100 | a = 'autre'
if (a == 345)
{
    Console.WriteLine("a == 345");
} else if (a < 10)
{
    Console.WriteLine("a < 10");
}
else if (a > 100)
{
    Console.WriteLine("a > 100");
}
else
{
    Console.WriteLine("autre");
}

if (true)
{
    //code
}
if (true)
    Console.WriteLine("true");

Console.ReadLine();
//debug watch