CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
    RETURNS NVARCHAR(10)
BEGIN
    IF (@salary < 30000)
        BEGIN
            RETURN 'Low'
        END
    IF (@salary BETWEEN 30000 AND 50000)
        BEGIN
            RETURN 'Average'
        END
    IF (@salary > 50000)
        BEGIN
            RETURN 'High'
        END
    RETURN 30120
END
