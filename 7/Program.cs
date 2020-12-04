using System;
using System.Collections.Generic;
using System.Linq;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        public void Start() 
        {
            string mappingString = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<string, char> mapping = new Dictionary<string, char>();
            for (int i = 1; i <= mappingString.Length; i++)
            {
                mapping.Add("" + i, mappingString[i-1]);
            }
            string message1 = "001";
            Console.WriteLine("Message {0}, unique values {1}", message1, Decode(message1, mapping));
            string message2 = "011";
            Console.WriteLine("Message {0}, unique values {1}", message2, Decode(message2, mapping));
            string message3 = "101";
            Console.WriteLine("Message {0}, unique values {1}", message3, Decode(message3, mapping));
            string message4 = "111";
            Console.WriteLine("Message {0}, unique values {1}", message4, Decode(message4, mapping));
            string message5 = "abc";
            Console.WriteLine("Message {0}, unique values {1}", message5, Decode(message5, mapping));
        }

        private int Decode(string message, Dictionary<string, char> mapping)
        {
            if (message.Length == 0)
            {
                return 1;
            }

            if (message.Length == 1)
            {
                return mapping.ContainsKey(message) ? 1 : 0;
            }

            int count = 0;
            if (mapping.ContainsKey(message[0].ToString()))
                count += Decode(message.Substring(1), mapping);

            if (mapping.ContainsKey(message.Substring(0, 2)))
                count += Decode(message.Substring(2), mapping);

            return count;
        }
    }
}
