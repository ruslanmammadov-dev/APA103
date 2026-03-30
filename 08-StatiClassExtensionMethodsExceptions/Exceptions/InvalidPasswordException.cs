using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(): base("Sifre bos ola bilmez ve ya 6 simvoldan az olmamalidir.") { }

        public InvalidPasswordException(string message) : base(message) { }
    }
}
