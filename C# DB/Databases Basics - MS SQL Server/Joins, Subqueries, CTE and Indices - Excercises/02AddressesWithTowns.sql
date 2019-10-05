SELECT
TOP (50)
FirstName
,
LastName
,
Name
,
AddressText
FROM Employees
         INNER JOIN Addresses A ON Employees.AddressID = A.AddressID
         INNER JOIN Towns T ON T.TownID = A.TownID
ORDER BY FirstName, LastName