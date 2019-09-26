CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName+' '+IIF(MiddleName IS NULL, '', MiddleName)+' '+LastName AS 'Full Name',JobTitle
FROM Employees
