using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution for problem #5");
            new Program().Start();
        }

        private void Start()
        {
            Console.Write("car(cons(3, 4)): {0}, cdr(cons(3, 4)): {1}", Car(Cons(3, 4)), Cdr(Cons(3, 4)));
        }

        private Tuple<int, int> Cons(int a, int b)
        {
            return Tuple.Create<int, int>(a, b);
        }

        private int Car(Tuple<int, int> tuple)
        {
            return tuple.Item1;
        }

        private int Cdr(Tuple<int, int> tuple)
        {
            return tuple.Item2;
        }
    }
}
