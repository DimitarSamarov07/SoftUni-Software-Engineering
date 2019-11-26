namespace _01InitialSetup
{
    using System.Data.SqlClient;
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connectionMaster = new SqlConnection(Configuration.ConnectionStringMaster);
           
            SqlConnection connectionMinions = new SqlConnection(Configuration.ConnectionStringMinionsDB);
            
            connectionMaster.Open();
            
            using (connectionMaster)
            {
                using SqlCommand createDbSqlCommand = new SqlCommand(Configuration.CreateDatabase, connectionMaster);
                
                createDbSqlCommand.ExecuteNonQuery();
               
                connectionMinions.Open();
                
                using (connectionMinions)
                {
                    foreach (var createQuery in Configuration.CreateQueries)
                    {
                        using SqlCommand createTablesSqlCommand = new SqlCommand(createQuery, connectionMinions);
                        
                        createTablesSqlCommand.ExecuteNonQuery();
                    }

                    foreach (var insertQuery in Configuration.InsertQueries)
                    {
                        using SqlCommand insertIntoTables = new SqlCommand(insertQuery, connectionMinions);
                        
                        insertIntoTables.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
