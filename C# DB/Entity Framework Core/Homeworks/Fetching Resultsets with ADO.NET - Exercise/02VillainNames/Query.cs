using System;
using System.Collections.Generic;
using System.Text;

namespace _02VillainNames
{
    public static class Query
    {
        public const string GetVillainNames = @"SELECT Name, COUNT(MV.MinionId) AS [CountOfMinions]
        FROM Villains V
            LEFT JOIN MinionsVillains MV ON V.Id = MV.VillainId
            GROUP BY Name
        HAVING COUNT(MV.MinionId) > 3
        ORDER BY CountOfMinions";
    }
}
