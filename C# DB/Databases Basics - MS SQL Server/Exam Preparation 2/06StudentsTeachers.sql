SELECT FirstName, LastName, COUNT(TeacherId) AS [TeachersCount]
FROM Students
         JOIN StudentsTeachers ST ON Students.Id = ST.StudentId
GROUP BY FirstName, LastName