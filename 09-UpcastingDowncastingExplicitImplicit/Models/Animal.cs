using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public void MakeSound() 
        {
            Console.WriteLine("Animal makes a sound");
        }
}
}
