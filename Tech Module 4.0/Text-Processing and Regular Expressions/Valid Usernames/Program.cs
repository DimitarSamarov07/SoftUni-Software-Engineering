using System;
using System.Collections.Generic;
using System.Linq;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(", ")
                .ToArray();

            for (int current = 0; current < words.Length; current++)
            {
                string word = words[current];
                bool isValid = false;

                if (word.Length>=3&&word.Length<=16)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        char currentChar = word[j];
                        if (char.IsLetterOrDigit(currentChar)||
                            currentChar=='-'||currentChar=='_')
                        {
                            isValid = true;
                        }

                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(word);
                    }
                }

            }

        }
    }
}
