using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (char j = 'a'; j < 'a'+number; j++)
            {
                for (char k = 'a'; k < 'a'+number; k++)
                {
                    for (char i = 'a'; i < 'a'+number; i++)
                    {
                        Console.WriteLine($"{j}{k}{i}");
                    }
                }
            }








        }
    }
}
