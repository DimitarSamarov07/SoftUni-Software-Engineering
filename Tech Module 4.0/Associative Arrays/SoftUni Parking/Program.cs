using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, string>();
            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfOperations; i++)
            {
                var input = Console.ReadLine().Split(" ").ToList();
                string command = input[0];
                string username = input[1];
               

                if (command=="register")
                {
                    string plateNumber = input[2];
                    if (!users.ContainsKey(username))
                    {
                        users[username] = plateNumber;
                        Console.WriteLine($"{username} registered {plateNumber} successfully");
                    }

                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[username]}");
                    }
                }

                else if (command=="unregister")
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }

                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    
                }
            }
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
