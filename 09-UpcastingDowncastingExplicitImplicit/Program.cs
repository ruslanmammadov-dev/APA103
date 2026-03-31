using _09_UpcastingDowncastingExplicitImplicit.Models;

namespace _09_UpcastingDowncastingExplicitImplicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int smallNumber = 100;
            double bigNumber = smallNumber;

            double pi = 3.14;
            int integerPi = (int)pi;

            Console.WriteLine($"Double: {pi} to: {integerPi}");

            // 1. Upcasting
            Dog myDog = new Dog();
            Animal myAnimal = myDog;
            myAnimal.MakeSound();

            // 2. Downcasting
            Dog myDog1 = (Dog)myAnimal;
            myDog1.Bark();

            if (myAnimal is Dog myDog2)
            {
                myDog2.Bark();
            }

            Currency wallet = 50.5; 
            Console.WriteLine(wallet.Amount);
        }
    }
}
