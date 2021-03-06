SELECT E.EmployeeID, E.FirstName, E.ManagerID, M.FirstName
FROM Employees AS E
         INNER JOIN Employees M ON E.ManagerID = M.EmployeeID
WHERE E.ManagerID IN (3, 7)
ORDER BY EmployeeID
