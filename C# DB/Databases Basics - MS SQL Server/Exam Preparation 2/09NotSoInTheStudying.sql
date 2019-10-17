SELECT CONCAT(FirstName, ' ', MiddleName, IIF(MiddleName IS NOT NULL, ' ', ''), LastName) AS [Full Name]
FROM Students
         LEFT JOIN StudentsSubjects SS ON Students.Id = SS.StudentId
WHERE SubjectId IS NULL
GROUP BY FirstName, MiddleName, LastName
ORDER BY [Full Name]
