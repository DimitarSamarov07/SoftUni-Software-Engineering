CREATE PROCEDURE usp_AssignProject(@employeeId INT, @projectID INT)
AS
    BEGIN TRANSACTION

DECLARE
    @numberOfProjects INT = (SELECT COUNT(EmployeeID)
                             FROM EmployeesProjects
                             WHERE EmployeeID = @employeeId)
    IF (@numberOfProjects >= 3)
        BEGIN
            ROLLBACK;
            RAISERROR ('The employee has too many projects!',16,1)
        END
    ELSE
        BEGIN
            INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
            VALUES (@employeeId, @projectID)
        END
    COMMIT