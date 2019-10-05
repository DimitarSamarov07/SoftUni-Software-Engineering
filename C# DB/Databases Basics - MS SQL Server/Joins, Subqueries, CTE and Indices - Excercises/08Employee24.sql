SELECT Employees.EmployeeID, FirstName, IIF(DATEPART(YEAR, StartDate) >= 2005, NULL, Name)
FROM Employees
         INNER JOIN EmployeesProjects EP on Employees.EmployeeID = EP.EmployeeID
         INNER JOIN Projects P on EP.ProjectID = P.ProjectID
WHERE Employees.EmployeeID = 24