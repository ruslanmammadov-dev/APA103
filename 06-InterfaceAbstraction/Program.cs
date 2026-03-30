using _06_InterfaceAbstraction.Actions;
using _06_InterfaceAbstraction.Models;

namespace _06_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICalculation calculator = new Calculation();

            Console.Write("Birinci ededi daxil edin: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci ededi daxil edin: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Emeliyyatı daxil edin (+, -, *, /): ");
            char operation = Convert.ToChar(Console.ReadLine());

            double result = calculator.Calculate(a, b, operation);

            Console.WriteLine($"\nNetice: {result}");
        }
    }
}
