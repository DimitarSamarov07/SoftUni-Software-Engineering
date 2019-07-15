using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paints = Console.ReadLine().Split(" ").ToList();
            int index = 0;
            int index2 = 0;
            while (true)
            {
                List<string> input = Console.ReadLine().Split(" ").ToList();
                string Event = input[0];
                if (Event=="END")
                {
                    break;
                }
                if (Event == "Reverse")
                {
                    paints.Reverse();
                    
                }
                
                
                
               
                
                if (Event == "Hide")
                {
                    if (paints.Contains(input[1]))
                    {
                        index = paints.IndexOf(input[1]);
                        paints.RemoveAt(index);
                    }
                    else
                    {
                        continue;
                    }
                }

               

                else if (Event=="Insert")
                {
                    
                    string paintingNumber = input[2];
                    if (paints.Contains(paintingNumber))
                    {
                        if ((index+1)>(paints.Count-1))
                        {
                            paints.Add(input[2]);
                        }
                        else
                        {
                            index = int.Parse(input[1]) + 1;
                            paints.Insert(index, paintingNumber);
                        }
                        
                        
                    }

                    else
                    {
                        continue;
                    }
                }

                else if (Event=="Switch")
                {

                    index = paints.IndexOf(input[1]);
                    index2 = paints.IndexOf(input[2]);
                    string first = input[1];
                    string second = input[2];

                    if (paints.Contains(input[1])&&paints.Contains(input[2]))
                    {
                        paints.RemoveAt(index);
                        paints.RemoveAt(index2);
                        paints.Insert(index, second);
                        paints.Insert(index2, first);
                    }

                    else
                    {
                        continue;
                    }

                }
                if (Event== "Change")
                {
                    if (paints.Contains(input[1]))
                    {
                        index = paints.IndexOf(input[1]);
                        

                        paints.RemoveAt(index);
                        paints.Insert(index, input[2]);
                    }
                }
            }
            for (int i = 0; i < paints.Count; i++)
            {
                if (paints[i]==" ")
                {
                    continue;
                }
                else
                {
                    Console.Write(String.Join(" ", paints[i])+" ");
                }
               
            }
            
        }
    }
}
