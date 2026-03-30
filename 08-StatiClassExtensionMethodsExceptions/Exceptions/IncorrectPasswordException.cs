using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; }

        public IncorrectPasswordException(int attemptsLeft): base($"Sifre yanlisdir. Sizin {attemptsLeft} cehdiniz qaldi.")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
}
