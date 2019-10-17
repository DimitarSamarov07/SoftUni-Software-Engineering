SELECT CONCAT(FirstName, ' ', LastName) AS [FullName], Name, CONCAT(Origin, ' - ', Destination) AS [Trip], Type
FROM Tickets
         JOIN Flights F ON Tickets.FlightId = F.Id
         JOIN Passengers P ON Tickets.PassengerId = P.Id
         JOIN Planes P2 ON F.PlaneId = P2.Id
         JOIN Luggages L ON Tickets.LuggageId = L.Id
         JOIN LuggageTypes LT ON L.LuggageTypeId = LT.Id
ORDER BY FullName, Name, Origin, Destination, Type