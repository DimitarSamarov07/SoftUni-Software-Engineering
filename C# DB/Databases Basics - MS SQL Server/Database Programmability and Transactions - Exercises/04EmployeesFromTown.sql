CREATE PROC usp_GetEmployeesFromTown @TownName NVARCHAR(200)
AS
BEGIN
    SELECT FirstName, LastName
    FROM Employees
             JOIN Addresses A on Employees.AddressID = A.AddressID
             JOIN Towns T on A.TownID = T.TownID
    WHERE T.Name = @TownName
END