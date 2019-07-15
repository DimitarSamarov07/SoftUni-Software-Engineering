using System;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            using System;
            using System.Linq;


namespace _03Zig_ZagArrays
    {
        class Program
        {
            static void Main(string[] args)
            {
                int lines = int.Parse(Console.ReadLine());

                int[] firstCombination = new int[lines];
                int[] secondCombination = new int[lines];

                for (int i = 0; i < lines; i++)
                {
                    int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    if (i % 2 == 0) // even row
                    {
                        firstCombination[i] = sequence[0];
                        secondCombination[i] = sequence[1];
                    }
                    else // odd row
                    {
                        firstCombination[i] = sequence[1];
                        secondCombination[i] = sequence[0];
                    }
                }

                Console.WriteLine(string.Join(" ", firstCombination));
                Console.WriteLine(string.Join(" ", secondCombination));
            }
        }
    }
}
    }
}
