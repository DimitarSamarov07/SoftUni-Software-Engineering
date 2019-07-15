using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split().ToArray();
            string[] secontArr = Console.ReadLine().Split().ToArray();
            string[] thirdtArr = new string[firstArr.Length + secontArr.Length];
            for (int i = 0; i <= secontArr.Length-1; i++)
            {
                for (int j = 0; i < firstArr.Length; i++)
                {
                    if (secontArr[i] == firstArr[j])
                    {
                        Console.WriteLine($"{secontArr[i]}");
                    }   
                        else
	                    {
                            
                        }
                    
                   
                
                }
            }

           





        }
    }
}
