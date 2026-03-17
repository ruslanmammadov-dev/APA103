using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class MainClass
    {
        // PUBLIC: Hər yerdən əlçatandır
        public string publicMesaj = "public";

        // INTERNAL: Yalnız eyni layihə daxilində əlçatandır
        internal string internalMesaj = "internal";

        // PRIVATE: Yalnız aid olduğu classın daxilində əlçatandır
        private string privateMesaj = "private";

        // PROTECTED: Yalnız aid olduğu classda və ondan miras alan  classlarda əlçatandır
        protected string protectedMesaj = "protected";

        // PROTECTED INTERNAL: Həm eyni layihə daxilində həm də digər layihələrdəki miras alan classlarda əlçatandır
        protected internal string protectedInternalMesaj = "protected internal";

        // PRIVATE PROTECTED: Yalnız eyni layihə daxilindəki miras alan classlarda əlçatandır
        private protected string privateProtectedMesaj = "private protected";

        public void TestMetodu()
        {
            // Private daxildə işləyir
            Console.WriteLine(privateMesaj);
        }

        public class BankHesabi
        {
            private decimal privateBalans; 

            public decimal Balans
            {
                get 
                { 
                    return privateBalans; 
                } 
                set
                {
                    if (value >= 0)
                        privateBalans = value;
                    else
                        Console.WriteLine("Balans menfi ola bilmez!");
                }
            }
        }
    }
}
