namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mdp = "toto2023";
            byte[] salt;
            Console.WriteLine($"{mdp} - {Security.HashPassword(mdp, out salt)}");
            Console.WriteLine("Hello, World!");
        }
    }
}