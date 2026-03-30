using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(): base("Istifadeci adi bos ola bilmez ve ya 3 simvoldan az olmamalidir.") { }

        public InvalidUsernameException(string message) : base(message) { }
    }
}
