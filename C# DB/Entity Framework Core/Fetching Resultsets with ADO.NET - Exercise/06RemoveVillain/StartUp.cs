using System;
using System.Data.SqlClient;
using _01InitialSetup;

namespace _06RemoveVillain
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Read the Input and set-up the connection
            int villainId = int.Parse(Console.ReadLine());
            SqlConnection minionsConnection = new SqlConnection(Configuration.ConnectionStringMinionsDB);
            
            minionsConnection.Open();
            using (minionsConnection)
            {
                // Enter the transaction
                SqlTransaction transaction = minionsConnection.BeginTransaction();
                using (transaction)
                {
                    try
                    {
                        //////////////////
                        //..............//
                        //....Checks....//
                        //..............//
                        //////////////////


                        //Check if villain exists 

                        //Check Command
                        SqlCommand villainCheckCommand = new SqlCommand(Query.SelectVillainName, minionsConnection, transaction);
                        villainCheckCommand.Parameters.AddWithValue("@villainId", villainId);

                        //Execute
                        string villainName = (string)villainCheckCommand.ExecuteScalar();

                        //If the value is null
                        if (villainName == null)
                        {
                            Console.WriteLine("No such villain was found.");
                            return;
                        }


                        ////////////////////////////////
                        //............................//
                        //....Update the Database.....//
                        //............................//
                        ///////////////////////////////

                        // Declare the required commands

                        SqlCommand releaseMinions = new SqlCommand(Query.ReleaseVillainsMinions, minionsConnection, transaction);
                        releaseMinions.Parameters.AddWithValue("@villainId", villainId);

                        SqlCommand deleteVillainCommand = new SqlCommand(Query.DeleteVillain, minionsConnection, transaction);
                        deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);

                        //Execute

                        int releasedMinions = releaseMinions.ExecuteNonQuery();
                        deleteVillainCommand.ExecuteNonQuery();

                        ///////////////////////////////
                        //...........................//
                        //....Print the results......//
                        //...........................//
                        ///////////////////////////////

                        //We use the name we got from the villain check
                        Console.WriteLine($"{villainName} was deleted.");
                        
                        //We use the number we got from the execution of the non query
                        Console.WriteLine($"{releasedMinions} minions were released.");

                        //And finally we commit the changes to the database if
                        //everything passes successfully
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        //If something goes wrong print the error message and rollback
                        Console.WriteLine("Exception with the following message occured:");
                        Console.WriteLine(e.Message);
                        Console.WriteLine();
                        Console.WriteLine("No changes were made to the database.");
                        transaction.Rollback();
                    }


                }

            }



        }
    }
}
