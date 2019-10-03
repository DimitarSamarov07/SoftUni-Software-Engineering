SELECT
TOP (10)
FirstName
,
LastName
,
DepartmentID
FROM Employees
WHERE Salary >
      (SELECT AVG(Salary)
       FROM Employees AS di
       WHERE di.DepartmentID = Employees.DepartmentID)
ORDER BY DepartmentID