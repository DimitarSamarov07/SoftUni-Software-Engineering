SELECT F.Id AS [FlightId], SUM(T.Price) AS [Price]
FROM Tickets T
         JOIN Flights F ON T.FlightId = F.Id
GROUP BY F.Id
ORDER BY Price DESC, F.Id