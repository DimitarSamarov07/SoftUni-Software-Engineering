using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leftInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rightInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> pairs =  new Queue<int>();
            Stack<int> leftSocks = new Stack<int>(leftInput);
            Queue<int> rightSocks = new Queue<int>(rightInput);

            while (leftSocks.Count!=0&&rightSocks.Count!=0)
            {
                while (leftSocks.Count!=0&&rightSocks.Count!=0)
                {
                    
                    int currentLeft = leftSocks.Peek();
                    int currentRight = rightSocks.Peek();

                    if (currentLeft>currentRight)
                    {
                        pairs.Enqueue(currentLeft+currentRight);
                        leftSocks.Pop();
                        rightSocks.Dequeue();
                    }

                    else if (currentLeft==currentRight)
                    {
                        rightSocks.Dequeue();
                        leftSocks.Pop();
                        currentLeft++;
                        leftSocks.Push(currentLeft);
                    }

                    else if (currentRight>currentLeft)
                    {
                        leftSocks.Pop();
                    }
                }
            }

            
            if (pairs.Any())
            {
                Console.WriteLine(pairs.Max());
                foreach (var pair in pairs)
                {
                    Console.Write(pair+" ");
                }
            }
            

        }
    }
}
