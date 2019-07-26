using System;
using System.Text;
using PlayersAndMonsters.Core;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static StringBuilder sb;
        public static void Main(string[] args)
        {
            sb = new StringBuilder();
            string input = String.Empty;
            ManagerController control = new ManagerController();
            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "AddPlayer")
                {
                    try
                    {
                        string type = line[1];
                        string username = line[2];
                        sb.AppendLine(control.AddPlayer(type, username));
                    }
                    catch (ArgumentException e)
                    {
                        sb.AppendLine(e.Message);
                    }

                }
                else if (line[0] == "AddCard")
                {
                    try
                    {
                        string type = line[1];
                        string name = line[2];
                        sb.AppendLine(control.AddCard(type, name));
                    }
                    catch (ArgumentException e)
                    {
                        sb.AppendLine(e.Message);
                    }

                }
                else if (line[0] == "AddPlayerCard")
                {
                    try
                    {
                        string username = line[1];
                        string cardName = line[2];
                        sb.AppendLine(control.AddPlayerCard(username, cardName));
                    }
                    catch (ArgumentException e)
                    {
                        sb.AppendLine(e.Message);
                    }

                }
                else if (line[0] == "Fight")
                {
                    try
                    {
                        string attackerUsername = line[1];
                        string enemyUsername = line[2];
                        sb.AppendLine(control.Fight(attackerUsername, enemyUsername));
                    }
                    catch (ArgumentException e)
                    {
                        sb.AppendLine(e.Message);
                    }

                }
                else if (line[0] == "Report")
                {
                    try
                    {
                        sb.AppendLine(control.Report());
                    }
                    catch (ArgumentException e)
                    {
                        sb.AppendLine(e.Message);
                    }

                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}