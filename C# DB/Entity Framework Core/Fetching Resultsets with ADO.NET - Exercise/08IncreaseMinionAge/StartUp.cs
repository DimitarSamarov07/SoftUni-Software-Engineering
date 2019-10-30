namespace _08IncreaseMinionAge
{
    using System;
    using System.Data.SqlClient;
    using _01InitialSetup;

    class StartUp
    {
        static void Main(string[] args)
        {
            //Read and split the input and set-up the connection
            string[] minionIds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            SqlConnection minionsConnection = new SqlConnection(Configuration.ConnectionStringMinionsDB);

            minionsConnection.Open();
            using (minionsConnection)
            {
                //Execute the command for each id
                foreach (var minionId in minionIds)
                {
                    // Declare, add parameters and execute the command
                    SqlCommand incrementAgeAndSetTitleCaseCommand = new SqlCommand(Query.IncrementMinionAgeAndSetTitleCase, minionsConnection);
                    incrementAgeAndSetTitleCaseCommand.Parameters.AddWithValue("@Id", minionId);
                    incrementAgeAndSetTitleCaseCommand.ExecuteNonQuery();
                }
                //Declare the read command
                SqlCommand readCommand = new SqlCommand(Query.SelectMinionsNameAndAge, minionsConnection);
                //Start the reader
                SqlDataReader reader = readCommand.ExecuteReader();
                
                //Get all the info and print
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int age = (int) reader["Age"];
                    Console.WriteLine($"{name} {age}");
                }
            }

            ;
        }
    }
}
