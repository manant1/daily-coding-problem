using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution for problem #4");
            Program program = new Program();
            int[] array1 = { 3, 4, -1, 1 };
            program.Start(array1);

            int[] array2 = { 1, 2, 0 };
            program.Start(array2);

            int[] array3 = { 2, 2, 2 };
            program.Start(array3);
        }

        private void Start(int[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= 0)
                {
                    continue;
                }

                if (array[i] >= array.Length)
                {
                    continue;
                }

                array[array[i] - 1] = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != i + 1)
                {
                    Console.Write(i + 1);
                    break;
                }
                
            }
            Console.WriteLine(" ");
        }
    }
}
