using System;
using System.Linq;

namespace Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var houses = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            var position = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Merry Xmas!")
                {
                    break;
                }
                else
                {
                    var command = input.Split();

                    var positionJump = int.Parse(command[1]);

                    if (position + positionJump >= houses.Length - 1)
                    {
                        position = (position + positionJump) % houses.Length;
                    }
                    else
                    {
                        position += positionJump;
                    }
                    if (houses[position] == 0)
                    {
                        Console.WriteLine($"House {position} will have a Merry Christmas.");
                        continue;
                    }
                    else
                    {
                        houses[position] -= 2;
                    }
                }
            }
            Console.WriteLine($"Santa's last position was {position}.");

            var counter = houses.Length;

            foreach (var house in houses)
            {
                if (house == 0)
                {
                    counter--;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {counter} houses.");
            }
        }
    }
}