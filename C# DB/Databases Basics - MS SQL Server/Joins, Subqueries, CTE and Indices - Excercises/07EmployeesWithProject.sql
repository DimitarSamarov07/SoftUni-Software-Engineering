SELECT
TOP (5)
Employees.EmployeeID
,
FirstName
,
Name
FROM Employees
         LEFT JOIN EmployeesProjects EP on Employees.EmployeeID = EP.EmployeeID
         LEFT JOIN Projects P on EP.ProjectID = P.ProjectID
WHERE EP.EmployeeID IS NOT NULL
  AND StartDate > '2002-08-13'
ORDER BY EmployeeID