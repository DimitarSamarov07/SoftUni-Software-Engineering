CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18, 2))
    RETURNS NVARCHAR(100)
AS
BEGIN
    IF (NOT EXISTS(SELECT Id
                   FROM Students
                   WHERE Id = @studentId))
        BEGIN
            RETURN 'The student with provided id does not exist in the school!'
        END
    IF (@grade > 6.00)
        BEGIN
            RETURN 'Grade cannot be above 6.00!'
        END
    DECLARE @secondGrade DECIMAL(3, 2) = @grade + 0.50;
    DECLARE @countOfGrades INT = (SELECT COUNT(Grade)
                                  FROM StudentsExams
                                  WHERE StudentId = @studentId
                                    AND Grade BETWEEN @grade AND @secondGrade)
    DECLARE @studentFirstName NVARCHAR(40) = (SELECT FirstName
                                              FROM Students
                                              WHERE Id = @studentId)
    RETURN CONCAT('You have to update ', @countOfGrades, ' grades for the student ', @studentFirstName)
END

