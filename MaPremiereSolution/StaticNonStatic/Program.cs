namespace StaticNonStatic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Humain.FaitesAAAAHHHHH();
            Humain x = new Humain(Console.ReadLine());
            //x.nom = "yves";
            x.DisTonNom();
            Program.AppelleMain();
        }

        public static void AppelleMain()
        {
            //Program.Main(null);
            DateTime date= DateTime.Now;
            DateTime d = new DateTime();
            DateTime d1 = new DateTime(2023, 12, 23);
            Console.WriteLine(d1.ToString());
            Console.WriteLine(date.ToString());
            Console.WriteLine(d1 - date);
        }
    }
}