using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine().ToLower();
            int total = 0;


            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == 'a' || sentence[i] == 'e' || sentence[i] == 'i' || sentence[i] == 'o' || sentence[i] == 'u')
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }
    }
}
