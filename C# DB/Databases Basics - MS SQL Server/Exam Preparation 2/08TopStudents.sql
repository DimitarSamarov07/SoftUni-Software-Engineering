SELECT
TOP 10
FirstName,
LastName,
CAST(AVG(Grade) AS DECIMAL(3, 2)) AS [Grade]
FROM StudentsExams
         JOIN Students S ON StudentsExams.StudentId = S.Id
GROUP BY FirstName, LastName
ORDER BY Grade DESC, FirstName, LastName