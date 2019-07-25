using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input= String.Empty;
            ManagerController control = new ManagerController();
            while ((input=Console.ReadLine())!="Exit")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (line[0]=="AddPlayer")
                {
                    try
                    {
                        string type = line[1];
                        string username = line[2];
                        Console.WriteLine(control.AddPlayer(type,username));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
                else if (line[0]=="AddCard")
                {
                    try
                    {
                        string type = line[1];
                        string name = line[2];
                        Console.WriteLine(control.AddCard(type,name));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
                else if (line[0]=="AddPlayerCard")
                {
                    try
                    {
                        string username = line[1];
                        string cardName = line[2];
                        Console.WriteLine(control.AddPlayerCard(username,cardName));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
                else if (line[0]=="Fight")
                {
                    try
                    {
                        string attackerUsername = line[1];
                        string enemyUsername = line[2];
                        Console.WriteLine(control.Fight(attackerUsername,enemyUsername));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
                else if (line[0]=="Report")
                {
                    try
                    {
                        Console.WriteLine(control.Report());
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }
            }
        }
    }
}