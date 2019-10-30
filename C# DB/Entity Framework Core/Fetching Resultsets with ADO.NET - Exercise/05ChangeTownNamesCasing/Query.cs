using System;
using System.Collections.Generic;
using System.Text;

namespace _05ChangeTownNamesCasing
{
    public static class Query
    {
        public const string ChangeTownNamesToUppercase = @"UPDATE Towns
                                                          SET Name = UPPER(Name)
                                                          WHERE Name IN (SELECT T.Name
                                                                         FROM Countries C
                                                                                  JOIN Towns T ON C.Id = T.CountryCode
                                                                         WHERE C.Name = @countryName)";

        public const string SelectTownNamesFromCountry = @"SELECT T.Name
                                                           FROM Countries C
                                                                    JOIN Towns T ON C.Id = T.CountryCode
                                                           WHERE C.Name = @countryName";

        public const string TakeCountryId = @"SELECT Id
                                              FROM Countries C
                                              WHERE C.Name = @countryName";

    }
}
