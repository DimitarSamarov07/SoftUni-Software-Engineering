namespace _04AddMinion
{
    using System;
    using System.Data.SqlClient;
    using _01InitialSetup;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInfo =
                Console.ReadLine().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] villainInfo =
                Console.ReadLine().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            SqlConnection minionsConnection = new SqlConnection(Configuration.ConnectionStringMinionsDB);
            minionsConnection.Open();

            using (minionsConnection)
            {
                //Begin the transaction 
                SqlTransaction transaction = minionsConnection.BeginTransaction();
                using (transaction)
                {

                    try
                    {
                        //Example for error

                        //SqlCommand sss = new SqlCommand("ssss", minionsConnection, transaction);
                        //sss.ExecuteNonQuery();


                        ///////////////////////////////////////////////////////
                        //...................................................//
                        //....Declare variables with info from the arrays....//
                        //...................................................//
                        ///////////////////////////////////////////////////////


                        //Minion
                        string minionName = minionInfo[1];
                        int minionAge = int.Parse(minionInfo[2]);
                        string townName = minionInfo[3];

                        //Villain
                        string villainName = villainInfo[1];

                        /////////////////////////////////////////////////
                        //.............................................//
                        //....Check And Eventually Insert And Print....//
                        //.............................................//
                        ////////////////////////////////////////////////


                        // 01. Town Check

                        //Check command
                        SqlCommand townCheck = new SqlCommand(Query.TakeTownId, minionsConnection, transaction);
                        townCheck.Parameters.AddWithValue("@name", townName);

                        //Execute
                        object townCheckResult = townCheck.ExecuteScalar();

                        //Add if the object if it doesn't exist
                        if (townCheckResult == null)
                        {
                            //Declare the parameters
                            SqlCommand townAdd = new SqlCommand(Query.TownInsertQuery, minionsConnection, transaction);
                            townAdd.Parameters.AddWithValue("@townName", townName);

                            //Execute and print
                            townAdd.ExecuteNonQuery();
                            Console.WriteLine($"Town {townName} was added to the database.");
                        }



                        // 02. Minion check (not in the problem description)

                        //Check command
                        SqlCommand minionCheck = new SqlCommand(Query.TakeMinionId, minionsConnection, transaction);
                        minionCheck.Parameters.AddWithValue("@name", minionName);
                        minionCheck.Parameters.AddWithValue("@age", minionAge);
                        object minionCheckResult = minionCheck.ExecuteScalar();

                        //Add if the object if it doesn't exist
                        if (minionCheckResult == null)
                        {
                            //Declare the first two parameters
                            SqlCommand minionAdd = new SqlCommand(Query.MinionInsertQuery, minionsConnection, transaction);
                            minionAdd.Parameters.AddWithValue("@name", minionName);
                            minionAdd.Parameters.AddWithValue("@age", minionAge);

                            //Get town's id
                            SqlCommand getTownId = new SqlCommand(Query.TakeTownId, minionsConnection, transaction);
                            getTownId.Parameters.AddWithValue("@name", townName);
                            int townId = (int)getTownId.ExecuteScalar();

                            //Declare the last parameter
                            minionAdd.Parameters.AddWithValue("@townId", townId);

                            //Execute and print result

                            minionAdd.ExecuteNonQuery();
                            Console.WriteLine($"Minion with name {minionName} was successfully added to the database!");
                        }



                        // 03.Villain Check

                        //Check command
                        SqlCommand villainCheck = new SqlCommand(Query.TakeVillainId, minionsConnection, transaction);
                        villainCheck.Parameters.AddWithValue("@name", villainName);
                        object villainCheckResult = villainCheck.ExecuteScalar();

                        //Add if the object if it doesn't exist
                        if (villainCheckResult == null)
                        {
                            //Declare the parameters
                            SqlCommand villainAdd = new SqlCommand(Query.VillainInsertQuery, minionsConnection, transaction);
                            villainAdd.Parameters.AddWithValue("@villainName", villainName);

                            //Execute and print result
                            villainAdd.ExecuteNonQuery();
                            Console.WriteLine($"Villain {villainName} was added to the database.");
                        }


                        ////////////////////////////////////
                        //................................//
                        //....Assign minion to villain....//
                        //................................//
                        ////////////////////////////////////


                        // Get minion's and villain's id

                        //Minion
                        SqlCommand minionIdCommand = new SqlCommand(Query.TakeMinionId, minionsConnection, transaction);
                        minionIdCommand.Parameters.AddWithValue("@name", minionName);
                        minionIdCommand.Parameters.AddWithValue("@age", minionAge);

                        //Villain
                        SqlCommand villainIdCommand = new SqlCommand(Query.TakeVillainId, minionsConnection, transaction);
                        villainIdCommand.Parameters.AddWithValue("@name", villainName);

                        //Execute and set the variables
                        int minionId = (int)minionIdCommand.ExecuteScalar();
                        int villainId = (int)villainIdCommand.ExecuteScalar();

                        //Assign the minion to the villain by inserting both of their Id's
                        // in the ,,MinionsVillains" table

                        SqlCommand inserter = new SqlCommand(Query.MinionsVillainsInsertQuery, minionsConnection, transaction);
                        inserter.Parameters.AddWithValue("@villainId", villainId);
                        inserter.Parameters.AddWithValue("@minionId", minionId);

                        //Execute and print result
                        inserter.ExecuteNonQuery();
                        Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

                        //And finally if everything passes successfully commit the changes to the database
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
