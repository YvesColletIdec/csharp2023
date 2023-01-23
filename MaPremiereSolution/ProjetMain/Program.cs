using ProjetMethodes;
namespace ProjetMain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(args.Length);
            foreach(string arg in args)
            {
                Console.WriteLine(arg);
            }
            Class1.Test();
            Console.ReadLine();
        }
    }
}