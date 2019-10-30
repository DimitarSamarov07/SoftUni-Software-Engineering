using System;
using System.Collections.Generic;
using System.Text;

namespace _03MinionNames
{
    public static class Query
    {
        public const string MinionsInfoQuery = @"SELECT M.Name, Age, ROW_NUMBER() OVER (ORDER BY M.Name) AS [RowNumber]
                                             FROM Minions M
                                                JOIN MinionsVillains MV ON M.Id = MV.MinionId
                                                JOIN Villains V ON MV.VillainId = V.Id
                                             WHERE V.Id = @Id
                                             ORDER BY M.Name";

        public const string VillainName = @"SELECT Name
                                             FROM Villains V
                                             WHERE Id = @Id";
    }
}
