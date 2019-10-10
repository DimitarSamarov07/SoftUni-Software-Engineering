SELECT SUM(IIF(MountainId IS NULL, 1, 0)) AS [Count]
FROM Countries
         LEFT OUTER JOIN MountainsCountries MC on Countries.CountryCode = MC.CountryCode
