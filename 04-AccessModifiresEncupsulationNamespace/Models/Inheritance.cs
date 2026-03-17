using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    internal class Inheritance:MainClass
    {
        public void Yoxla()
        {
            // Console.WriteLine(privateMesaj); // Xəta verəcək! Çünki privatedır

            Console.WriteLine(protectedMesaj);   // İşləyir! Çünki protecteddır
            Console.WriteLine(protectedInternalMesaj); // İşləyir!
            Console.WriteLine(privateProtectedMesaj);  // İşləyir! Eyni layihədəyik
        }
    }
}
