using System;
using System.Collections.Generic;
using System.Text;

namespace _08IncreaseMinionAge
{
    public static class Query
    {
        public const string IncrementMinionAgeAndSetTitleCase = @"UPDATE Minions
                                                                  SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)),
                                                                      Age += 1
                                                                  WHERE Id = @Id";

        public const string SelectMinionsNameAndAge = @"SELECT Name, Age
                                                        FROM Minions";

    }
}
