using System;
using System.Collections.Generic;
using System.Linq;

namespace On_the_Way_to_Annapurna
{
    class Program
    {

        static void Main(string[] args)
        {
            string line = String.Empty;
            var storesAndItems = new Dictionary<string, List<string>>();
            while ((line = Console.ReadLine()) != "END")
            {
                List<string> input = line.Split(new string[]{"->", ","}, StringSplitOptions.RemoveEmptyEntries).ToList();
                string copy = String.Empty;         
                string command = input[0];
                string store = input[1];
                if (command == "Remove")
                {
                    
                   
                    if (storesAndItems.ContainsKey(store))
                    {
                        storesAndItems.Remove(store);
                    }

                }

                if (command == "Add")
                {
                    string item = input[2];
                    
                    if (input.Count==3)
                    {
                        if (!storesAndItems.ContainsKey(store))
                        {
                            storesAndItems.Add(store, new List<string>());
                            storesAndItems[store].Add(item);
                        }

                        else
                        {
                            storesAndItems[store].Add(item);
                        }
                    }

                    else if (input.Count>3)
                    {

                        
                        if (!storesAndItems.ContainsKey(store))
                        {
                            storesAndItems.Add(store, new List<string>());
                            
                            
                            for (int i = 2; i < input.Count; i++)
                            {
                                storesAndItems[store].Add(input[i]);
                            }
                        }

                        else
                        {
                            for (int i = 2; i < input.Count; i++)
                            {
                                storesAndItems[store].Add(input[i]);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Stores list:");
            foreach (var kvp in storesAndItems.OrderByDescending(x=>x.Value.Count).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine(kvp.Key);

                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    Console.WriteLine($"<<{kvp.Value[i]}>>");
                    
                }
                    
                
                
            }
            
            
            
        }
    }
}
