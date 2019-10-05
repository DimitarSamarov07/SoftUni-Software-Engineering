SELECT
TOP (5)
EmployeeID
,
JobTitle
,
A.AddressID
,
AddressText
FROM Employees
         INNER JOIN Addresses A on Employees.AddressID = A.AddressID
ORDER BY A.AddressID
