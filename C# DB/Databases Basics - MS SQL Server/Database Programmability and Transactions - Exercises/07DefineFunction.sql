CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(50))
    RETURNS BIT
BEGIN
    SET @setOfLetters = LOWER(@setOfLetters)
    SET @word = LOWER(@word)
    DECLARE @index SMALLINT = 1;
    DECLARE @isComprised BIT = 1;
    WHILE(@index <= LEN(@word))
        BEGIN
            DECLARE @Current NVARCHAR = SUBSTRING(@word, @index, 1)
            DECLARE @ResultIndex INT = CHARINDEX(@Current, @setOfLetters)
            IF (@ResultIndex = 0)
                BEGIN
                    SET @isComprised = 0
                    BREAK
                END
            SET @index+=1
        END

    RETURN @isComprised
END
