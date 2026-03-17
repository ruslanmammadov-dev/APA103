using _04_AccessModifiresEncupsulationNamespace.Models;
using static _04_AccessModifiresEncupsulationNamespace.Models.MainClass;

namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainClass main = new MainClass();
            Inheritance inheritance = new Inheritance();

            Console.WriteLine("--- Obyekt uzerindən muraciet ---");
            //Console.WriteLine(main.protectedMesaj); Xəta verəcək! Çünki miras almir
            Console.WriteLine(main.protectedInternalMesaj); // İşləyir!
            //Console.WriteLine(main.privateProtectedMesaj); Xəta verəcək! Çünki miras almir
            Console.WriteLine(main.publicMesaj); // İşləyir!
            //Console.WriteLine(main.privateMesaj); Xəta verəcək! Çünki privatedır
            Console.WriteLine(main.internalMesaj); // İşləyir!


            Console.WriteLine("\n--- Miras daxilinden muraciet ---");
            inheritance.Yoxla();

            BankHesabi hesab = new BankHesabi();

            hesab.Balans = 100; 
            Console.WriteLine(hesab.Balans); 

            hesab.Balans = -50; 
        }
    }
}
