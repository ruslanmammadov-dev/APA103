namespace _01_C_IntroMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            ButunEmeliyyatlar(40, 5);
            //Task 2
            TekCut(14, 20, 35, 40, 57, 60, 100);
            //Task 3
            int[] ededler = [14, 20, 35, 40, 57, 60, 100];
            int Cem = BolunenlerinCemi(ededler);
            Console.WriteLine("Cem: " + Cem);
            //Task 4
            Console.WriteLine("Cumleni daxil edin:");
            string cumle = Console.ReadLine();

            Console.WriteLine("Simvolu daxil edin:");
            char simvol = Convert.ToChar(Console.ReadLine());

            int say = SimvoluSay(cumle, simvol);
            Console.WriteLine($"{simvol} simvolu {say} defe tapildi");
        }

        static void ButunEmeliyyatlar(double a, double b)
        {
            Console.WriteLine($"Cem = {a + b}");
            Console.WriteLine($"Ferq = {a - b}");
            Console.WriteLine($"Vurma = {a * b}");

            if (b != 0)
            {
                Console.WriteLine($"Bölme = {a / b}");
            }
            else
            {
                Console.WriteLine("Sıfıra bolmek mumkun deyil!");
            }
        }

        static void TekCut(params int[] numbers)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.WriteLine("Cutler " + numbers[i]);
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    Console.WriteLine("Tekler " + numbers[i]);
                }
            }
        }

        static int BolunenlerinCemi(int[] ededler)
        {
            int cem = 0;

            for (int i = 0; i < ededler.Length; i++)
            {
                if (ededler[i] % 4 == 0 && ededler[i] % 5 == 0)
                {
                    cem += ededler[i]; 
                }
            }

            return cem;
        }

        static int SimvoluSay(string cumle, char simvol)
        {
            int say = 0;

            cumle = cumle.ToLower();

            for (int i = 0; i < cumle.Length; i++)
            {
                if (cumle[i] == simvol)
                {
                    say++;
                }
            }
            return say;
        }
    }

}
