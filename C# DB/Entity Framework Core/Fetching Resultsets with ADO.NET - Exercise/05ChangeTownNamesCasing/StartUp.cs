
namespace _05ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using _01InitialSetup;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Read from the console and initialize the collection
            string countryName = Console.ReadLine();
            List<string> updatedTowns = new List<string>();

            //Setup the connection
            SqlConnection minionsConnection = new SqlConnection(Configuration.ConnectionStringMinionsDB);
            minionsConnection.Open();

            using (minionsConnection)
            {
                //////////////////
                //..............//
                //....Checks....//
                //..............//
                //////////////////

                //Check if country exists

                SqlCommand checkCountry = new SqlCommand(Query.TakeCountryId, minionsConnection);
                checkCountry.Parameters.AddWithValue("@countryName", countryName);
                object resultCountry = checkCountry.ExecuteScalar();

                if (resultCountry == null)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                //Check if there are towns in the country

                SqlCommand checkTowns = new SqlCommand(Query.SelectTownNamesFromCountry, minionsConnection);
                checkTowns.Parameters.AddWithValue("@countryName", countryName);
                object resultTowns = checkTowns.ExecuteScalar();

                if (resultTowns == null)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                ///////////////////////////////
                //...........................//
                //....Update the database....//
                //...........................//
                ///////////////////////////////


                SqlCommand uppercaseCommand = new SqlCommand(Query.ChangeTownNamesToUppercase, minionsConnection);
                uppercaseCommand.Parameters.AddWithValue("@countryName", countryName);
                uppercaseCommand.ExecuteNonQuery();


                /////////////////////////////////////
                //.................................//
                //....Get and print the results....//
                //.................................//
                /////////////////////////////////////


                SqlCommand selectChangedTowns = new SqlCommand(Query.SelectTownNamesFromCountry, minionsConnection);
                selectChangedTowns.Parameters.AddWithValue("@countryName", countryName);
                SqlDataReader reader = selectChangedTowns.ExecuteReader();

                //Add the changed town names to the collection

                while (reader.Read())
                {
                    string nameToAdd = (string)reader["Name"];
                    updatedTowns.Add(nameToAdd);
                }

                //And finally print the results
                Console.WriteLine($"{updatedTowns.Count} town names were affected.");
                Console.WriteLine($"[{String.Join(", ", updatedTowns)}]");
            }


        }
    }
}
