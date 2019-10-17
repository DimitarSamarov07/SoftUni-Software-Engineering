SELECT CONCAT(FirstName, ' ', LastName) AS [FullName], Origin, Destination
FROM Flights F
         JOIN Tickets T ON F.Id = T.FlightId
         JOIN Passengers P ON T.PassengerId = P.Id
ORDER BY FullName, Origin, Destination