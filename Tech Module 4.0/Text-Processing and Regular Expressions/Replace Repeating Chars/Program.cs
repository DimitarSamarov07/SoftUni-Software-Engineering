using System;


namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();

            string result = "";
            result += letters[0]; // първия символ във стринга

            for (int i = 1; i < letters.Length; i++)
            {
                if (letters[i - 1] != letters[i])
                    result += letters[i];
            }
            Console.WriteLine(result);
        }
    }
}