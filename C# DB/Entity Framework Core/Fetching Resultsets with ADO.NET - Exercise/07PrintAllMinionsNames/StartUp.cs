namespace _07PrintAllMinionsNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using _01InitialSetup;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the connection and set-up the connection
            List<string> originalNames = new List<string>();
            SqlConnection minionsConnection = new SqlConnection(Configuration.ConnectionStringMinionsDB);
            minionsConnection.Open();

            using (minionsConnection)
            {
                //The command for getting all minion's names
                SqlCommand readCommand = new SqlCommand(Query.SelectAllMinionsNames, minionsConnection);
                SqlDataReader reader = readCommand.ExecuteReader();

                //Add the names to the collection
                while (reader.Read())
                {
                    originalNames.Add((string)reader["Name"]);
                }

                //Check if there are any minions
                if (originalNames.Count == 0)
                {
                    Console.WriteLine("There are no minions!");
                    return;
                }

                //Print the names in old order and get ready for the new order
                Console.WriteLine($"Original order:{Environment.NewLine + String.Join(Environment.NewLine, originalNames)}");
                Console.WriteLine("------------------------");
                Console.WriteLine("New order:");

                //Loop while there are no names left in the collection
                while (originalNames.Count != 0)
                {
                    //Print the name from the first index and then remove it from the collection
                    Console.WriteLine(originalNames[0]);
                    originalNames.RemoveAt(0);

                    //Check if there are any names left
                    if (originalNames.Count==0)
                    {
                        break;
                    }
                    //Print the name from the last index and then remove it from the collection
                    Console.WriteLine(originalNames.Last());
                    originalNames.RemoveAt(originalNames.Count-1);
                }
            }
        }
    }
}
