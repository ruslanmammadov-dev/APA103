using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Dog : Animal
    {
        public void Bark() => Console.WriteLine("Woof! Woof!");
    }
}
