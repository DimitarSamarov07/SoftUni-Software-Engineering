using System;

namespace _02HelensAbduction
{
    class Program
    {
        static char[][] field;
        static int rows;
        static int energy;
        static int parisRow;
        static int parisCol;

        static void Main(string[] args)
        {
            energy = int.Parse(Console.ReadLine());
            rows = int.Parse(Console.ReadLine());
            field = new char[rows][];

            InitializeField();

            while (energy > 0)
            {
                string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = directions[0];
                int enemyRow = int.Parse(directions[1]);
                int enemyCol = int.Parse(directions[2]);

                field[enemyRow][enemyCol] = 'S'; // sets spartans
                MoveParis(direction);
            }

            field[parisRow][parisCol] = 'X';
            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            End();
        }

        // Moves Paris and main logic of the program
        private static void MoveParis(string direction)
        {
            if (direction == "up")
            {
                if (IsInside(parisRow - 1, parisCol))
                {
                    parisRow--;
                }
            }
            else if (direction == "down")
            {
                if (IsInside(parisRow + 1, parisCol))
                {
                    parisRow++;
                }
            }
            else if (direction == "left")
            {
                if (IsInside(parisCol - 1, parisRow))
                {
                    parisCol--;
                }
            }
            else if (direction == "right")
            {
                if (IsInside(parisCol + 1, parisRow))
                {
                    parisCol++;
                }
            }

            energy--;

            if (field[parisRow][parisCol] == 'S')
            {
                energy -= 2;
                field[parisRow][parisCol] = '-';
            }
            else if (field[parisRow][parisCol] == 'H')
            {
                field[parisRow][parisCol] = '-';
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                End();
            }
        }

        // Initializes field and finds Paris position
        private static void InitializeField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();
                field[row] = new char[values.Length];

                for (int col = 0; col < values.Length; col++)
                {
                    field[row][col] = values[col];

                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                        field[row][col] = '-';
                    }
                }
            }
        }

        // Checks field dimensions
        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow < field.Length && desiredCol < field.Length &&
                   desiredRow >= 0 && desiredCol >= 0;
        }

        // Prints the field and ends the program
        private static void End()
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }

            Environment.Exit(0);
        }
    }
}