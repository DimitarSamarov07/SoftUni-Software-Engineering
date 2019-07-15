using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in input)
            {
                char encryptedSymbol = (char)(symbol + 3);
                sb.Append(encryptedSymbol);
            }

            Console.WriteLine(sb);
        }
    }
}
