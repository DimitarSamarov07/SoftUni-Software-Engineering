using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            List<string> chatHistory = new List<string>();
            while (true)
            {
                List<string> command = Console.ReadLine().Split(" ").ToList();

                if (command[0] == "end")
                {
                    foreach (var item in chatHistory)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                }
                else if (command[0]=="Chat")
                {
                    chatHistory.Add(command[1]);
                }

                else if (command[0]=="Delete")
                {
                    if (chatHistory.Contains(command[1]))
                    {
                        index = chatHistory.IndexOf(command[1]);
                        chatHistory.RemoveAt(index);
                    }
                    else
                    {
                        continue;
                    }
                }

                else if (command[0]=="Edit")
                {
                    if (chatHistory.Contains(command[1]))
                    {
                        index = chatHistory.IndexOf(command[1]);
                        chatHistory.RemoveAt(index);
                        chatHistory.Insert(index, command[2]);
                    }
                }
                else if (command[0]=="Pin")
                {
                    if (chatHistory.Contains(command[1]))
                    {
                        index = chatHistory.IndexOf(command[1]);
                        chatHistory.RemoveAt(index);
                        chatHistory.Add(command[1]);
                    }
                }
                else if (command[0]=="Spam")
                {
                    command.RemoveAt(0);
                    for (int i = 0; i < command.Count; i++)
                    {
                        chatHistory.Add(command[i]);
                    }
                }

            }
            
        }
    }
}
