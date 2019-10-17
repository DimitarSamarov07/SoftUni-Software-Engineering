SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM Students
         LEFT JOIN StudentsExams SE ON Students.Id = SE.StudentId
WHERE SE.StudentId IS NULL
ORDER BY [Full Name]