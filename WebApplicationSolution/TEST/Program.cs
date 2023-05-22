namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mdp = "toto2023";
            string hash = "1CF64FD4B7038E114D4CA35DFAB1564CB3B9EA0C9A96717B78C8D4ED3C4D8D3D:9546D7934C4C6E3A13DAF1332E3C6495:50000:SHA256";
            //Console.WriteLine($"{mdp} - {Security.Hash(mdp)}");
            Console.WriteLine(Security.Verify(mdp, hash));
            Console.WriteLine("Hello, World!");
        }
    }
}