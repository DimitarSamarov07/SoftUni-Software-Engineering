SELECT *
FROM Planes
WHERE LOWER(Name) LIKE '%tr%'
ORDER BY Id, Name, Range