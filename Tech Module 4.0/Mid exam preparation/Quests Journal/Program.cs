using System;
using System.Collections.Generic;
using System.Linq;

namespace Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            List<string> questJournal = Console.ReadLine().Split(", ").ToList();
            int index = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input=="Retire!")
                {
                    break;
                }
                List<string> command = input.Split(" - ").ToList();
                string Event = command[0];
                string word = command[1];

                if(Event=="Start")
                {
                    if (!questJournal.Contains(word))
                    {
                        questJournal.Add(word);
                    }
                    else
                    {
                        continue;
                    }
                }

                else if (Event=="Complete")
                {
                    if (questJournal.Contains(word))
                    {
                        index = questJournal.IndexOf(word);
                        questJournal.RemoveAt(index);
                    }

                    else
                    {
                        continue;
                    }
                }

                else if (Event=="Renew")
                {
                    if (questJournal.Contains(word))
                    {
                        index = questJournal.IndexOf(word);
                        questJournal.RemoveAt(index);
                        questJournal.Add(word);
                    }

                    else
                    {
                        continue;
                    }
                }

                else if (Event=="Side Quest")
                {
                    List<string> WordAndSide = word.Split(":").ToList();
                    string wordPart = WordAndSide[0];
                    string sidePart = WordAndSide[1];
                    if (questJournal.Contains(wordPart)&&!questJournal.Contains(sidePart))
                    {
                        index = questJournal.IndexOf(wordPart)+1;
                        questJournal.Insert(index, sidePart);
                    }
                }
                
            }
            Console.WriteLine(String.Join(", ",questJournal));
        }
    }
}
