SELECT FirstName, LastName, HireDate, Name AS [DeptName]
FROM Employees
         INNER JOIN Departments D on Employees.DepartmentID = D.DepartmentID
WHERE D.Name IN ('Sales', 'Finance')
  AND HireDate > '1-1-1999'