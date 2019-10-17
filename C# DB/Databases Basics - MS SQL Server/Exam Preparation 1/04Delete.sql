DELETE
FROM Tickets
WHERE FlightId IN (SELECT FlightId
                   FROM Flights
                   WHERE Destination = 'Ayn Halagim')

DELETE
FROM Flights
WHERE Destination = 'Ayn Halagim'