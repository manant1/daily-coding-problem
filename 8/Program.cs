using System;
using System.Linq;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] array1 = { 2, 4, 6, 2, 5 };
            Console.WriteLine(program.Start(array1));
            int[] array2 = { 5, 1, 1, 5 };
            Console.WriteLine(program.Start(array2));
            int[] array3 = { 10, 5, 1, 7, 0 };
            Console.WriteLine(program.Start(array3));
            int[] array4 = { 10, 11, 99, 7, 1, 8, 10 };
            Console.WriteLine(program.Start(array4));
        }

        private int Start(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }
            if (numbers.Length == 2)
            {
                return Max(numbers[0], numbers[1]);
            }

            numbers[0] = Max(0, numbers[0]);
            numbers[1] = Max(numbers[0], numbers[1]);

            for(int i = 2; i < numbers.Length; i++)
            {
                int number = numbers[i];
                numbers[i] = Max(number + numbers[i - 2], numbers[i - 1]);
            }
            return numbers.Last();
        }

        private int Max(int first, int second)
        {
            return first > second ? first : second;
        }
    }
}
