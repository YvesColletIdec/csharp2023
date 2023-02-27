using System.Runtime.CompilerServices;

namespace POO2
{
    public class Program : Voiture
    {
        static void Main(string[] args)
        {
            VoitureElectrique ve = new VoitureElectrique();
            Voiture a = new Voiture();
            a.SetMarque("BMW");
            a.SetCylindree(1500);
            string t = a.GetMarque();
            Console.WriteLine(a.Description());
            Voiture b = new Voiture();
            b.SetMarque("Ford");
            b.SetCylindree(2000);
            Console.WriteLine(b.Description());

            Moto m = new Moto();
            m.Couleur = "rouge";
            t = m.Couleur;
            m.Is125cm3= true;
            bool x = m.Is125cm3;
            Console.WriteLine("fini");
            Humain h = new Humain("F");
            h.Nom = "Sonia";
            Console.WriteLine(h.Presentation());
            b._aUnMoteur = true;
            List<int> list = null;

        }
    }

}