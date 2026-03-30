using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(): base("Sistemde bele bir istifadeci tapilmadi.") { }

        public UserNotFoundException(string username): base($"'{username}' adli istifadeci tapilmadi.") { }
    }
}
