using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_InterfaceAbstraction.Actions;

namespace _06_InterfaceAbstraction.Models
{
    public class Calculation : ICalculation
    {
        public double Calculate(double n1, double n2, char op)
        {
            switch (op)
            {
                case '+': 
                    return n1 + n2;
                case '-': 
                    return n1 - n2;
                case '*': 
                    return n1 * n2;
                case '/':
                    if (n2 == 0)
                    {
                        Console.WriteLine("Xəta: Sıfıra bölmək olmaz!");
                        return 0;
                    }
                    return n1 / n2;
                default:
                    Console.WriteLine("Yanlış əməliyyat seçilib!");
                    return 0;
            }
        }
    }
}
