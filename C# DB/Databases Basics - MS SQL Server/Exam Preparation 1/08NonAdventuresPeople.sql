SELECT FirstName, LastName, Age
FROM Passengers
         LEFT JOIN Tickets T ON Passengers.Id = T.PassengerId
WHERE T.Id IS NULL
ORDER BY Age DESC, FirstName, LastName