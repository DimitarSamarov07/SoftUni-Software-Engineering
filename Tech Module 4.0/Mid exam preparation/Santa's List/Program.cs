using System;
using System.Collections.Generic;
using System.Linq;


namespace Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            List<string> noisyKids = Console.ReadLine().Split("&").ToList();
            int position = 0;



            while (true)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                string command = input[0];
                if (command == "Finished!")
                {
                    break;

                }
                string kidName = input[1];
                
                

                if (command=="Bad")
                {
                    if (!noisyKids.Contains(kidName))
                    {
                        noisyKids.Insert(0, kidName);
                    }                    
                }
                else if (command=="Good")
                {
                    if (noisyKids.Contains(kidName))
                    {
                         position = noisyKids.IndexOf(kidName);
                        noisyKids.RemoveAt(position);
                    }
                   
                }
                else if (command=="Rename")
                {
                    if (noisyKids.Contains(kidName))
                    {
                        string newName = input[2];
                        position = noisyKids.IndexOf(kidName);
                        noisyKids.RemoveAt(position);
                        noisyKids.Insert(position, newName);
                    }

                }
                else if (command=="Rearrange")
                {
                    if (noisyKids.Contains(kidName))
                    {
                        position = noisyKids.IndexOf(kidName);
                        noisyKids.RemoveAt(position);
                        noisyKids.Add(kidName);
                    }
                }
            }
               Console.Write(String.Join(", ",noisyKids));
            
             



        }
        
    }
}
