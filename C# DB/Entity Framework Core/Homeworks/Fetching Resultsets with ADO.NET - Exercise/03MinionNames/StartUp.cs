namespace _03MinionNames
{
    using System;
    using System.Data.SqlClient;
    using _01InitialSetup;

    class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection minionsConnection = new SqlConnection(Configuration.ConnectionStringMinionsDB);

            minionsConnection.Open();

            using (minionsConnection)
            {
                using SqlCommand villainNameSqlCommand = new SqlCommand(Query.VillainName, minionsConnection);

                villainNameSqlCommand.Parameters.AddWithValue("@Id", villainId);

                string villainName = (string)villainNameSqlCommand.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                using SqlCommand minionsQuery = new SqlCommand(Query.MinionsInfoQuery, minionsConnection);
                minionsQuery.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader reader = minionsQuery.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine($"Villain: {villainName}");

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }

                    while (reader.Read())
                    {
                        long rowNumber = (long)reader["RowNumber"];
                        string minionName = (string)reader["Name"];
                        int minionAge = (int)reader["Age"];

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                    }
                }
            }
        }
    }
}
