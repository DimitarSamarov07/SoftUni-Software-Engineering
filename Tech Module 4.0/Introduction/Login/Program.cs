using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = new string(username.Reverse().ToArray());
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input==password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }

               if(input!=password)
               {
                    counter++;
                    if (counter<4)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        
                    }
                    if (counter==4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    

               }
                


            }


        }
    }
}
