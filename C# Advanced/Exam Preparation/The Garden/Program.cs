using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace The_Garden
{
    class Program
    {
        public static int LettuceCount;
        public static int CarrotsCount;
        public static int PotatoesCount;
        public static int HarmedCount;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] jagged = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                string[] col = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                jagged[i] = col;

            }

            string input;
            while ((input = Console.ReadLine()) != "End of Harvest")
            {
                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = line[0];
                int row = int.Parse(line[1]);
                int col = int.Parse(line[2]);
                if (command == "Harvest")
                {
                    try
                    {
                        if (jagged[row][col] != " ")
                        {
                            string item = jagged[row][col];
                            GetAndAdd(item);
                            jagged[row][col] = " ";
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }

                else if (command == "Mole")
                {
                    bool forceStop = false;
                    string direction = line[3];

                    for (int r = row; ;)
                    {
                        if (forceStop)
                        {
                            break;
                        }
                        for (int c = col; ;)
                        {
                            try
                            {
                                if (jagged[row][col] != " ")
                                {
                                    jagged[row][col] = " ";
                                    //public field
                                    HarmedCount++;
                                }
                                
                            }
                            catch (Exception)
                            {
                                forceStop = true;
                                break;
                            }

                            if (direction == "up")
                            {
                                row++;
                                row++;
                            }

                            else if (direction == "right")
                            {
                                col++;
                                col++;
                            }

                            else if (direction == "left")
                            {
                                col--;
                                col--;
                            }

                            else if (direction == "down")
                            {
                                row--;
                                row--;
                            }
                        }
                    }





                }
            }

            foreach (string[] item in jagged)
            {
                Console.WriteLine(String.Join(" ", item));
            }

            Console.WriteLine($"Carrots: {CarrotsCount}"+ Environment.NewLine+
            $"Potatoes: {PotatoesCount}"+Environment.NewLine+
            $"Lettuce: {LettuceCount}"+Environment.NewLine+
            $"Harmed vegetables: {HarmedCount}");

        }

        public static void GetAndAdd(string item)
        {
            if (item == "L")
            {
                //type = "Lettuce"
                LettuceCount++;
            }

            if (item == "C")
            {
                //type = "Carrots"
                CarrotsCount++;
            }
            if (item == "P")
            {
                // type = "Potatoes"
                PotatoesCount++;
            }

        }
    }
}
