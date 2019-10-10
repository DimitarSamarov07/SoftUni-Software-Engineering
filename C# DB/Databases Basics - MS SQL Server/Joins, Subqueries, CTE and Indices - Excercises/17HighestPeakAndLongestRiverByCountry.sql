SELECT
TOP 5
Countries.CountryName
,
MAX(Elevation) AS [HighestPeakElevation]
,
MAX(Length) AS [LongestRiverLength]
FROM Countries
         LEFT OUTER JOIN MountainsCountries MC on Countries.CountryCode = MC.CountryCode
         LEFT OUTER JOIN Mountains M ON MC.MountainId = M.Id
         LEFT OUTER JOIN Peaks P ON M.Id = P.MountainId
         LEFT OUTER JOIN CountriesRivers CR on Countries.CountryCode = CR.CountryCode
         LEFT OUTER JOIN Rivers R2 on CR.RiverId = R2.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC