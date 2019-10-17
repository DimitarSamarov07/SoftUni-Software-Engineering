CREATE TABLE Deleted_Employees
(
    EmployeeId   INT PRIMARY KEY IDENTITY ,
    FirstName    VARCHAR(50) NOT NULL,
    LastName     VARCHAR(50) NOT NULL,
    MiddleName   VARCHAR(50) NOT NULL,
    JobTitle     VARCHAR(50) NOT NULL,
    DepartmentId INT         NOT NULL FOREIGN KEY REFERENCES Departments (DepartmentID),
    Salary       MONEY       NOT NULL
)

CREATE TRIGGER tr_delete_Employees
    ON Employees
    FOR DELETE
    AS
BEGIN
    INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
    SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary
    FROM Deleted
END
