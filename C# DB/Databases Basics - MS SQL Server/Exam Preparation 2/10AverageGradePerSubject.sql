SELECT Name, AVG(Grade)
FROM StudentsSubjects
         JOIN Subjects S ON StudentsSubjects.SubjectId = S.Id
GROUP BY Name, SubjectId
ORDER BY SubjectId