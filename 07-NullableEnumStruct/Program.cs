using _07_NullableEnumStruct.Enums;
using _07_NullableEnumStruct.Models;

namespace _07_NullableEnumStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrinkOrder o1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            o1.DisplayOrder();
            o1.UpdateStatus(OrderStatus.Preparing);
            o1.UpdateStatus(OrderStatus.Ready);
            o1.UpdateStatus(OrderStatus.Delivered);

            DrinkOrder o2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            o2.DisplayOrder();
            o2.UpdateStatus(OrderStatus.Ready);

            DrinkOrder o3 = new DrinkOrder(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            o3.DisplayOrder();

            Console.WriteLine("\n--- Enum GetValues ---");
            foreach (DrinkType dt in Enum.GetValues(typeof(DrinkType)))
                Console.WriteLine("Icki: " + dt);

            string teaStr = DrinkType.Tea.ToString();
            DrinkSize mediumSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");

            Console.WriteLine("\n--- Statistika ---");
            decimal total = o1.Price + o2.Price + o3.Price;
            Console.WriteLine("Umumi sifaris sayi: 3");
            Console.WriteLine("Umumi mebleg: " + total + " AZN");

        }
    }
}
