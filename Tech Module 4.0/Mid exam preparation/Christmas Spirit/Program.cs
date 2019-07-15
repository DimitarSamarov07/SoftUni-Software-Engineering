using System;

namespace Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int christmasSpirit = 0;
            int sum = 0;
            int ornamentSet = 2;
            int treeSkirt = 5;
            int treeGarland = 3;
            int treeLight = 15;


            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                if (currentDay % 11 == 0)
                {
                    quantity += 2;
                }
                
                
                if (currentDay % 2 == 0)
                {
                    sum += ornamentSet * quantity;
                    christmasSpirit += 5;
                }
                if (currentDay % 3 == 0)
                {
                    sum += (treeGarland + treeSkirt) * quantity;
                    christmasSpirit += 13;
                }
                if (currentDay % 5 == 0)
                {
                    sum += treeLight * quantity;
                    if (currentDay % 3 == 0)
                    {
                        christmasSpirit += 30;
                    }
                    
                        christmasSpirit += 17;
                    
                }
                if (currentDay % 10 == 0)
                {
                    
                    
                    if (currentDay == days && currentDay % 10 == 0)
                    {
                        christmasSpirit -= 30;
                    }
                    christmasSpirit -= 20;
                    sum += treeSkirt + treeGarland + treeLight;
                }
                


            }

            Console.WriteLine($"Total cost: {sum}");
            Console.WriteLine($"Total spirit: {christmasSpirit}");

        }

    }
}
