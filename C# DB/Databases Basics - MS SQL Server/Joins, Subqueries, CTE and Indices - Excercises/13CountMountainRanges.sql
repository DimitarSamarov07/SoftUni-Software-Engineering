SELECT CountryCode, COUNT(CountryCode) AS [MountainRanges]
FROM MountainsCountries
         JOIN Mountains M on MountainsCountries.MountainId = M.Id
WHERE CountryCode IN ('BG', 'RU', 'US')
GROUP BY CountryCode