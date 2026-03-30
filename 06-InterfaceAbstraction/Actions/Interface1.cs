using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_InterfaceAbstraction.Actions
{
    public interface ICalculation
    {
        double Calculate(double n1, double n2, char op);
    }
}
