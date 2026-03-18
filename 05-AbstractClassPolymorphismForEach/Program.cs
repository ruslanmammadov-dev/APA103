using _05_AbstractClassPolymorphismForEach.Models;

namespace _05_AbstractClassPolymorphismForEach
{
    class Program
    {
        static void Main()
        {
            Car car1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 4, 500, true, 220);
            Car car2 = new Car("BMW", "320i", 2022, "99-BB-999", 4, 480, true, 235);
            Car car3 = new Car("Toyota", "Camry", 2021, "77-CC-777", 4, 524, true, 210);

            Motorcycle motor1 = new Motorcycle("Yamaha", "R1", 2023, "10-MM-100", 998, false, 299, "Sport");
            Motorcycle motor2 = new Motorcycle("Harley-Davidson", "Fat Boy", 2022, "10-HD-022", 1868, true, 180, "Cruiser");

            Truck truck1 = new Truck("MAN", "TGX", 2020, "90-TT-900", 18, 3, 12, 120);
            Truck truck2 = new Truck("Volvo", "FH16", 2021, "90-VV-016", 25, 4, 18, 110);

            Console.WriteLine("--- NEQLİYYAT MELUMATLARI ---");
            car1.ShowCarInfo(); 
            Console.WriteLine($"500km Yanacaq: {car1.CalculateFuelCost(500)} AZN");
            car2.ShowCarInfo(); 
            Console.WriteLine($"500km Yanacaq: {car2.CalculateFuelCost(500)} AZN");
            car3.ShowCarInfo(); 
            Console.WriteLine($"500km Yanacaq: {car3.CalculateFuelCost(500)} AZN");

            motor1.ShowMotorcycleInfo(); 
            Console.WriteLine($"300km Yanacaq: {motor1.CalculateFuelCost(300)} AZN");
            motor2.ShowMotorcycleInfo(); 
            Console.WriteLine($"300km Yanacaq: {motor2.CalculateFuelCost(300)} AZN");

            truck1.ShowTruckInfo(); 
            Console.WriteLine($"800km Yanacaq: {truck1.CalculateFuelCost(800)} AZN");
            truck2.ShowTruckInfo(); 
            Console.WriteLine($"800km Yanacaq: {truck2.CalculateFuelCost(800)} AZN");

            Console.WriteLine("\n--- YUK ELAVE EDILMESİ (MAN TGX) ---");
            truck1.LoadCargo(5);
            Console.WriteLine($"Yeni yanacaq xerci (800km): {truck1.CalculateFuelCost(800)} AZN");

            Console.WriteLine("\n--- UMUMİ STATISTIKA ---");
            int totalVehicles = 7;
            double avgSpeed = (car1.MaxSpeed + car2.MaxSpeed + car3.MaxSpeed + motor1.MaxSpeed + motor2.MaxSpeed + truck1.MaxSpeed + truck2.MaxSpeed) / 7.0;

            Console.WriteLine($"Umumi neqliyyat sayi: {totalVehicles}");
            Console.WriteLine($"Orta maksimum suret: {avgSpeed} km/saat");

            Console.WriteLine($"En bahalı yanacaq xerci: Volvo FH16 ({truck2.CalculateFuelCost(800)} AZN)");
        }
    }
}
