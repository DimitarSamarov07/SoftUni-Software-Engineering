CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
BEGIN
    ALTER TABLE Departments
        ALTER COLUMN ManagerID INT NULL;

    DELETE
    FROM EmployeesProjects
    WHERE EmployeeID IN (SELECT EmployeeID
                         FROM Employees
                         WHERE DepartmentID = @departmentId)
    UPDATE Departments
    SET ManagerID=NULL
    WHERE DepartmentID = @departmentId

    UPDATE Employees
    SET ManagerID = NULL
    WHERE ManagerID IN (SELECT e.EmployeeID
                        FROM Employees AS e
                        WHERE e.DepartmentID = @departmentId);

    DELETE
    FROM Employees
    WHERE DepartmentID = @departmentId

    DELETE
    FROM Departments
    WHERE DepartmentID = @departmentId


    SELECT COUNT(DepartmentID)
    FROM Employees
    WHERE DepartmentID = @departmentId
END
