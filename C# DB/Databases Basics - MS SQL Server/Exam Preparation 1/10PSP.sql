SELECT Name, Seats, COUNT(PassengerId) AS [Passengers Count]
FROM Tickets
         JOIN Passengers P ON Tickets.PassengerId = P.Id
         JOIN Flights F ON Tickets.FlightId = F.Id
         RIGHT JOIN Planes P2 ON F.PlaneId = P2.Id
GROUP BY Name, Seats
ORDER BY [Passengers Count] DESC, Name, Seats
