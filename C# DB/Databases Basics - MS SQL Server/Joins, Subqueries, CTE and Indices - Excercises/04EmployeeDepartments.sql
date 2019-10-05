SELECT
TOP (5)
EmployeeID
,
FirstName
,
Salary
,
Name AS [DepartmentName]
FROM Employees
         INNER JOIN Departments D ON Employees.DepartmentID = D.DepartmentID
WHERE Salary > 15000
ORDER BY D.DepartmentID