using _08_StatiClassExtensionMethodsExceptions.Exceptions;

namespace _08_StatiClassExtensionMethodsExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginSystem system = new LoginSystem();

            while (true)
            {
                try
                {
                    Console.WriteLine("\n--- Giris Paneli ---");
                    Console.Write("Istifadeci adini daxil edin: ");
                    string uname = Console.ReadLine();

                    Console.Write("Sifreni daxil edin: ");
                    string pass = Console.ReadLine();

                    if (system.Login(uname, pass))
                    {
                        break;
                    }
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine("XETA: " + ex.Message);
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine("XETA: " + ex.Message);
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine("XETA: " + ex.Message);
                    Console.WriteLine("Movcud istifadeciler: admin, student, teacher");
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine("XEBARDARLIQ: " + ex.Message);
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine("KRITIK XETA: " + ex.Message);
                    Console.WriteLine("Hesabin acilmasi ucun admin ile elaqe saxlayin.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GOZLENILMEZ XETA: " + ex.Message);
                }
            }
        }
    }
}
