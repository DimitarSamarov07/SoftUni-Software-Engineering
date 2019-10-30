﻿namespace _09IncreaseAgeStoredProcedure
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using _01InitialSetup;

    public class StartUp
    {
        private const string DbName = "MinionsDB";
        private const string ProcedureName = "usp_GetOlder";

        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionStringMinionsDB, DbName));

            connection.Open();

            using (connection)
            {
                int minionId = int.Parse(Console.ReadLine());

                // Create procedure
                using SqlCommand createCommand = new SqlCommand(Query.CreateProcedure, connection);
                createCommand.ExecuteNonQuery();

                // Exec procedure
                using SqlCommand execCommand = new SqlCommand(ProcedureName, connection);

                execCommand.CommandType = CommandType.StoredProcedure;
                execCommand.Parameters.AddWithValue("@Id", minionId);
                execCommand.ExecuteNonQuery();

                // Create reader to show result after procedure executes
                using SqlCommand selectCommand = new SqlCommand(Query.SelectMinionNameAndAge, connection);
                selectCommand.Parameters.AddWithValue("@Id", minionId);

                using SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} - {minionAge} years old");
                }
            }
        }
    }
}