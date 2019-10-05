SELECT EmployeeID,
       FirstName,
       LastName,
       D.Name AS [DepartmentName]
FROM Employees
         INNER JOIN Departments D ON Employees.DepartmentID = D.DepartmentID
WHERE D.Name = 'Sales'
ORDER BY EmployeeID