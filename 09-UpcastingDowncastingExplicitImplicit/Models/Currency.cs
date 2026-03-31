using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Currency
    {
        public double Amount { get; set; }

        public static implicit operator Currency(double value)
        {
            return new Currency { Amount = value };
        }
    }
}
