SELECT
TOP (3)
Employees.EmployeeID
,
FirstName
FROM Employees
         LEFT JOIN EmployeesProjects EP on Employees.EmployeeID = EP.EmployeeID
WHERE EP.ProjectID IS NULL