using System;
using System.Collections.Generic;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution for problem #1");
            Program program = new Program();

            int number = 17;
            List<int> numbers = new List<int>() { 10, 15, 3, 7 };
            program.Solution(numbers, number);
        }

        private void Solution(List<int> numbers, int number)
        {
            if (numbers.Count < 2 || number == null)
            {
                Console.WriteLine("Where should be two or more list items and it cannot be null");
                return;
            }
            HashSet<int> possibleNumbers = new HashSet<int>();
            foreach (int n in numbers)
            {
                if (possibleNumbers.Contains(n))
                {
                    Console.WriteLine("Contains. {0} + {1}", number - n, n);
                    break;
                }
                else
                {
                    possibleNumbers.Add(number - n);
                }
            }
        }
    }
}
