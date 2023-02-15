using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string line = "";
            var tokens = new string[100];
            line = Console.ReadLine();
            int k = 0;
            for(int i = 0; i < line.Length; i++)
            {
                char s = line[i];
                if (s == ' ')
                {
                    
                    k++;
                }
                else
                {
                    tokens[k] += s;
                }
            }
            Console.WriteLine(tokens);
        }
    }
}