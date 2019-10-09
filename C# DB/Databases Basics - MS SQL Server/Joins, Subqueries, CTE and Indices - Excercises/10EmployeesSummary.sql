SELECT
TOP (50)
Employees.EmployeeID
,
Employees.FirstName + ' ' + Employees.LastName AS [EmployeeName]
,
E.FirstName + ' ' + E.LastName AS [ManagerName]
,
D.Name AS [DepartmentName]
FROM Employees
         JOIN Departments D on Employees.DepartmentID = D.DepartmentID
         JOIN Employees E ON Employees.ManagerID = E.EmployeeID
ORDER BY EmployeeID