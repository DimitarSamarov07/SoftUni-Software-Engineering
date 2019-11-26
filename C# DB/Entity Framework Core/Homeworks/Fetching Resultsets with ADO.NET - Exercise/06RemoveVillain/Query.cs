using System;
using System.Collections.Generic;
using System.Text;

namespace _06RemoveVillain
{
    public static class Query
    {
        public const string SelectVillainName = @"SELECT Name
                                                  FROM Villains
                                                  WHERE Id = @villainId";


        public const string ReleaseVillainsMinions = @"DELETE
                                                       FROM MinionsVillains
                                                       WHERE VillainId = @villainId";

        public const string DeleteVillain = @"DELETE
                                              FROM Villains
                                              WHERE Id = @villainId";

    }
}
