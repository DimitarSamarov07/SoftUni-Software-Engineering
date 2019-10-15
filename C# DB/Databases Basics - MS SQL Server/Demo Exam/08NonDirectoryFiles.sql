SELECT f.Id,
       f.[Name],
       CONCAT(f.Size, 'KB') AS [Size]
FROM Files AS f
         LEFT JOIN Files AS fi ON fi.ParentId = f.Id
WHERE fi.Id IS NULL
ORDER BY f.Id,
         f.[Name],
         f.Size DESC