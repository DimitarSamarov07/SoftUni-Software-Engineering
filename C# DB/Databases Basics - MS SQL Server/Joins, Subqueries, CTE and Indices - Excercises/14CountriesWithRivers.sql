SELECT TOP 5 CountryName, RiverName
FROM Countries
         LEFT OUTER JOIN CountriesRivers CR on Countries.CountryCode = CR.CountryCode
         LEFT OUTER JOIN Rivers R on CR.RiverId = R.Id
WHERE Countries.ContinentCode = 'AF'
ORDER BY CountryName