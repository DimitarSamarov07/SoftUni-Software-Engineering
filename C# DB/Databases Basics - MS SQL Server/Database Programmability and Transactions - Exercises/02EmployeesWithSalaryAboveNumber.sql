CREATE PROC usp_GetEmployeesSalaryAboveNumber @Amount DECIMAL(18, 4)
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @Amount
