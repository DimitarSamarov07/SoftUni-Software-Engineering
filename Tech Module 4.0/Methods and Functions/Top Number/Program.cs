using System;
using System.Linq;
using System.Numerics;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string b = "";
            int sum = 0;

            //checks and print
            for (int i = 0; i <= input; i++)
            {
                //creting a string variant of i
                b = i.ToString();
                //check is it odd
                int count = 0;


                //checking the sum of the digits
                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] % 2 != 0)
                    {
                        count++;
                    }
                    sum = sum + b[j];

                }
                //check if the sum is divisible by 8
                if (sum % 8 == 0 && count > 0)
                {
                    //print the master numbers
                    Console.WriteLine(i);

                }

                //sum reset
                sum = 0;
            }

        }
    }
}