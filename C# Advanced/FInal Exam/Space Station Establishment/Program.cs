using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Space_Station_Establishment
{
    class Program
    {
        public static int blackHoleRow;
        public static int blackHoleCol;
        public static int blackHoleRow2;
        public static int blackHoleCol2;
        public static int playerRow;
        public static int playerCol;
        public static char[][] jagged;
        public static int starPower;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            starPower = 0;
            jagged = new char[rows][];
            blackHoleRow = -1;
            blackHoleCol = -1;
            blackHoleRow2 = -1;
            blackHoleCol2 = -1;
            bool IsInVoid = false;
            bool Success = false;

            for (int r = 0; r < rows; r++)
            {
                string read = Console.ReadLine();
                char[] col = read.ToCharArray();


                jagged[r] = col;
                //Adding and finding places of the items
                for (int c = 0; c < col.Length; c++)
                {
                    if (char.IsLetter(col[c]))
                    {
                        if (col[c] == 'O')
                        {
                            if (blackHoleRow == -1)
                            {
                                blackHoleRow = r;
                                blackHoleCol = c;
                            }

                            else if (blackHoleRow2 == -1)
                            {
                                blackHoleRow2 = r;
                                blackHoleCol2 = c;
                            }
                        }

                        else if (col[c] == 'S')
                        {
                            playerRow = r;
                            playerCol = c;
                        }
                    }
                }
            }

            while (true)
            {

                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (IsInside(playerRow + 1, playerCol))
                    {
                        jagged[playerRow][playerCol] = '-';
                        playerRow += 1;
                        IsStarSetStar(jagged[playerRow][playerCol]);
                        if (starPower >= 50)
                        {
                            Success = true;
                            break;
                        }
                        //setting new player place
                        jagged[playerRow][playerCol] = 'S';
                    }
                    else
                    {
                        IsInVoid = true;
                        break;
                    }
                }

                else if (command == "down")
                {
                    if (IsInside(playerRow - 1, playerCol))
                    {
                        jagged[playerRow][playerCol] = '-';
                        playerRow -= 1;
                        IsStarSetStar(jagged[playerRow][playerCol]);
                        if (starPower >= 50)
                        {
                            Success = true;
                            break;
                        }
                        //setting new player place
                        jagged[playerRow][playerCol] = 'S';
                    }
                    else
                    {
                        IsInVoid = true;
                        break;
                    }
                }

                else if (command == "right")
                {
                    if (IsInside(playerRow, playerCol + 1))
                    {
                        jagged[playerRow][playerCol] = '-';
                        playerCol += 1;
                        IsStarSetStar(jagged[playerRow][playerCol]);
                        IsBlackHoleSet(jagged[playerRow][playerCol]);
                        jagged[playerRow][playerCol] = '-';
                        if (starPower >= 50)
                        {
                            Success = true;
                            break;
                        }
                        //setting new player place
                        jagged[playerRow][playerCol] = 'S';
                    }
                    else
                    {
                        IsInVoid = true;
                        break;
                    }
                }

                else if (command == "left")
                {
                    if (IsInside(playerRow, playerCol - 1))
                    {
                        
                        playerCol -= 1;
                        IsStarSetStar(jagged[playerRow][playerCol]);
                        IsBlackHoleSet(jagged[playerRow][playerCol]);
                        jagged[playerRow][playerCol] = '-';
                        if (starPower >= 50)
                        {
                            Success = true;
                            break;
                        }
                        //setting new player place
                        jagged[playerRow][playerCol] = 'S';
                    }

                    else
                    {
                        IsInVoid = true;
                    }
                }
            }

            if (IsInVoid)
            {
                jagged[playerRow][playerCol] = '-';
                Console.WriteLine($"Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {starPower}");
                foreach (char[] item in jagged)
                {
                    Console.WriteLine(String.Join("",item));
                }
            }

            else if (Success)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starPower}");
                foreach (char[] item in jagged)
                {
                    Console.WriteLine(String.Join("",item));
                }
            }



        }

        private static void IsBlackHoleSet(char item)
        {
            if (jagged[playerRow][playerCol] == 'O')
            {
                if (blackHoleRow != -1 && blackHoleCol != -1 && blackHoleRow2 != -1 && blackHoleRow2 != -1)
                {
                    if (blackHoleRow == playerRow && blackHoleCol == playerCol)
                    {
                        jagged[playerRow][playerCol] = '-';
                        jagged[blackHoleRow][blackHoleCol] = '-';
                        jagged[blackHoleRow2][blackHoleCol2] = '-';
                        playerRow = blackHoleRow2;
                        playerCol = blackHoleCol2;
                        blackHoleRow = -1;
                        blackHoleCol = -1;
                        blackHoleRow2 = -1;
                        blackHoleCol2 = -1;
                    }

                    if (blackHoleRow2 == playerRow && blackHoleCol2 == playerCol)
                    {
                        jagged[playerRow][playerCol] = '-';
                        jagged[blackHoleRow][blackHoleCol] = '-';
                        jagged[blackHoleRow2][blackHoleCol2] = '-';
                        playerRow = blackHoleRow;
                        playerCol = blackHoleCol;
                        blackHoleRow = -1;
                        blackHoleCol = -1;
                        blackHoleRow2 = -1;
                        blackHoleCol2 = -1;

                    }
                }

            }
        }

        private static void IsStarSetStar(char item)
        {
            if (char.IsDigit(item))
            {
                int sum = int.Parse(item.ToString());
                starPower += sum;
            }
        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow < jagged.Length && desiredCol < jagged.Length &&
                   desiredRow >= 0 && desiredCol >= 0;
        }

       
    }
}
