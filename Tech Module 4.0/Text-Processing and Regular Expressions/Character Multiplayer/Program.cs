using System;

namespace Character_Multiplayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine()
                .Split();

            string firstWord = tokens[0];
            string secondWord = tokens[1];

            string longerWord = String.Empty;
            string shorterWord = String.Empty;

            int totalSum = 0;

            if (firstWord.Length >= secondWord.Length)
            {
                longerWord = firstWord;
                shorterWord = secondWord;
            }

            else
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                totalSum += longerWord[i] * shorterWord[i];
            }
            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                totalSum += longerWord[i];
            }

            Console.WriteLine(totalSum);

        }
    }
}
