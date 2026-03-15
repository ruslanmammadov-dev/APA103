namespace _02_HeapStackRefOutArrayResize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };

            ArrayResize(numbers, 4, 5, 6);
        }

        static void ArrayResize(int[] sourceArray, params int[] newElements)
        {
            int newLength = sourceArray.Length + newElements.Length;

            int[] newArray = new int[newLength];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                newArray[i] = sourceArray[i];
            }

            for (int i = 0; i < newElements.Length; i++)
            {
                newArray[sourceArray.Length + i] = newElements[i];
            }

            for (int i = 0; i < newArray.Length; i++)
            {
                Console.Write(newArray[i] + " ");
            }
        }
    }
}
