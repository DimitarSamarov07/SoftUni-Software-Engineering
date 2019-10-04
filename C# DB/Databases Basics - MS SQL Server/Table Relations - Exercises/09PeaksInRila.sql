SELECT MountainRange,PeakName,Elevation
FROM Peaks
JOIN Mountains M on Peaks.MountainId = M.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC