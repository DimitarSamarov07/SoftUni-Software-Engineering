namespace _02VillainNames
{
    using System;
    using _01InitialSetup;
    using System.Data.SqlClient;
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connectionMinions = new SqlConnection(Configuration.ConnectionStringMinionsDB);

            connectionMinions.Open();

            using (connectionMinions)
            {
                using SqlCommand command = new SqlCommand(Query.GetVillainNames, connectionMinions);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int countOfMinions = (int)reader["CountOfMinions"];
                    Console.WriteLine($"{villainName} - {countOfMinions}");
                }
            }
        }
    }
}
