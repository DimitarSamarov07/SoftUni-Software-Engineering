SELECT CountryCode, MountainRange, PeakName, Elevation
FROM Peaks
         JOIN Mountains M on Peaks.MountainId = M.Id
         JOIN MountainsCountries MC on M.Id = MC.MountainId
WHERE CountryCode = 'BG'
  AND Elevation > 2835
ORDER BY Elevation DESC