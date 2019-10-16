CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel NVARCHAR(10))
AS
BEGIN
    SELECT FirstName, LastName
    FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END