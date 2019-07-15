using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("&").ToList();
            string keyPattern16 = @"^[A-Za-z0-9]{16}$";
            string keyPattern25 = @"[A-Za-z0-9]{25}";
            List<string> results = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                bool IsMatch1 = Regex.IsMatch(input[i], keyPattern16);
                bool IsMatch2 = Regex.IsMatch(input[i], keyPattern25);

                if (IsMatch1 || IsMatch2)
                {
                    StringBuilder current = new StringBuilder();
                    string currentKey = input[i].ToUpper();

                    for (int j = 0; j < currentKey.Length; j++)
                    {
                        char currentChar = currentKey[j];
                        if (char.IsDigit(currentChar))
                        {
                            string charString = currentChar.ToString();
                            int number = int.Parse(charString);
                            number = 9 - number;
                            char newChar = char.Parse(number.ToString());
                            current.Append(newChar);
                        }

                        else
                        {
                            current.Append(currentChar);
                        }
                    }
                    if (current.Length == 16)
                    {
                        current.Insert(4, '-');
                        current.Insert(9, '-');
                        current.Insert(14, '-');                       
                    }

                    else if (current.Length == 25)
                    {
                        current.Insert(5, '-');
                        current.Insert(11, '-');
                        current.Insert(17, '-');
                        current.Insert(23, '-');
                    }
                    results.Add(current.ToString());
                }
            }


            Console.WriteLine(String.Join($", ", results));




        }
    }
}
