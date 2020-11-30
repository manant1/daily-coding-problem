using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution for problem #2");
            Program program = new Program();
            int[] array1 = { 1, 2, 3, 4, 5 };
            program.Solution(array1);
            Console.WriteLine("\r\n--------------");
            int[] array2 = { 3, 2, 1 };
            program.Solution(array2);
        }

        private void Solution(int[] array)
        {
            if (array.Length < 2 || array == null)
            {
                Console.WriteLine("Where should be two or more array items and it cannot be null");
                return;
            }

            int valuesProduct = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                valuesProduct *= array[i];
            }

            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = valuesProduct / array[i];
                Console.Write(" {0} ", array[i]);
            }
            Console.Write("]");
        }
    }
}