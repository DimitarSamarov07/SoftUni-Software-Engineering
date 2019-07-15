using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                              .Split()
                              .Select(int.Parse)
                              .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandLine = command.Split();

                ExecuteCommands(numbers,commandLine);

            }

            Console.WriteLine(string.Join(" ", numbers));






        }

        private static void ExecuteCommands(List<int> numbers, string[] commandLine)
        {
            if (commandLine[0] == "Add")
            {
                numbers.Add(int.Parse(commandLine[1]));

            }

            else if (commandLine[0] == "Remove")
            {
                int index = int.Parse(commandLine[1]);
                if (index >= 0 && index <= numbers.Count)
                {
                    numbers.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (commandLine[0] == "Insert")
            {
                int index = int.Parse(commandLine[2]);
                int element = int.Parse(commandLine[1]);
                if (index >= 0 && index <= numbers.Count)
                {
                    numbers.Insert(index, element);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }


            }
            else if (commandLine[0] == "Shift")
            {
                string direction = commandLine[1];
                int count = int.Parse(commandLine[2]);
                ShiftList(numbers,direction,count);
            }





        }

        private static void ShiftList(List<int> numbers, string direction, int count)
        {
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int tempNumber = numbers[0];
                    numbers.Add(tempNumber);
                    numbers.RemoveAt(0);
                }
            }

            else if (direction=="right")
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);
                }
                

            }





        }



    }
}
