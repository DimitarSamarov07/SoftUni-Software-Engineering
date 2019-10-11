SELECT TOP 5 WITH TIES CountryName,
       ISNULL(PeakName ,'(no highest peak)') AS [Highest Peak Name],
       ISNULL(MAX(Elevation),0) AS [Highest Peak Elevation],
       ISNULL(MountainRange, '(no mountain)') AS [Mountain]
FROM Countries
         LEFT OUTER JOIN MountainsCountries MC on Countries.CountryCode = MC.CountryCode
         LEFT OUTER JOIN Mountains M on MC.MountainId = M.Id
         LEFT OUTER JOIN Peaks P on M.Id = P.MountainId
GROUP BY CountryName,PeakName,MountainRange
ORDER BY CountryName,[Highest Peak Name]