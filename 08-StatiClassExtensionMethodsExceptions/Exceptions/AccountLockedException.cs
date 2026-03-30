using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class AccountLockedException : Exception
    {
        public AccountLockedException(): base("Hesabiniz cox sayli sehv cehd sebebiyle bloklanib.") { }
    }
}
