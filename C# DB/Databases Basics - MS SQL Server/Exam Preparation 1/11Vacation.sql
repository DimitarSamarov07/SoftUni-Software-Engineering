CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
    RETURNS VARCHAR(50)
AS
BEGIN
    IF (@peopleCount <= 0)
        BEGIN
            RETURN 'Invalid people count!'
        END
    DECLARE @targetId INT = (SELECT Tickets.Id
                             FROM Tickets
                                      JOIN Flights F ON Tickets.FlightId = F.Id
                             WHERE Origin = @origin
                               AND Destination = @destination)
    IF (@targetId IS NULL)
        BEGIN
            RETURN 'Invalid flight!'
        END
    DECLARE @pricePerPerson DECIMAL(18, 2) = (SELECT Price
                                              FROM Tickets
                                              WHERE Id = @targetId)
    DECLARE @result VARCHAR(50) = CONCAT('Total price ',(@pricePerPerson * @peopleCount))
    RETURN @result
END