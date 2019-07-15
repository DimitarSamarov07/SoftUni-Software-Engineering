using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace solutions
{
    class Program
    {
        public static void Main()
        {
            var patern = @"^([A-Z][a-z|\s|']+):([A-Z|\s]+)\b";

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else
                {
                    Regex result = new Regex(patern);
                    if (result.IsMatch(input))
                    {
                        var line = input.Split(':');
                        var key = line[0].Length;
                        var newString = "";
                        foreach (var item in input)
                        {
                            if (item >= 65 && item <= 90)
                            {
                                if (item + key > 90)
                                {
                                    newString += (char)(key - (90 - item) + 64);
                                }
                                else
                                {
                                    newString += (char)(item + key);
                                }
                            }
                            if (item >= 97 && item <= 122)
                            {
                                if (item + key > 122)
                                {
                                    newString += (char)(key - (122 - item) + 96);
                                }
                                else
                                {
                                    newString += (char)(item + key);
                                }
                            }
                            if (item == ':')
                            {
                                newString += '@';
                            }
                            if (item == ' ')
                            {
                                newString += ' ';
                            }
                            if (item == '\'')
                            {
                                newString += '\'';
                            }
                        }
                        Console.WriteLine($"Successful encryption: {newString}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
            }
        }
    }
}