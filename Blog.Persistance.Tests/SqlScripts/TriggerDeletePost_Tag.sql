-- Triggers
-- TO DO: How to handle inserting multiple values?

CREATE TRIGGER triggerAfterDeleteOfPost_Tag ON [dbo].[Post_Tag] 
FOR DELETE
AS
	DECLARE @id	int;
	DECLARE @count	int;

	SELECT @id = i.TagId from deleted i;
	SELECT @count = tags.Count from [dbo].[Tags] tags where Id = @id;
	
	SET @count = @count - 1; -- Decrease 'Count' value after value is deleted from Post_Tag table'
	PRINT 'Count: ' + STR(@count);
	IF @count = 0
		BEGIN
			DELETE FROM [dbo].[Tags]
			WHERE Id = @id;
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Tags]
			SET Count = @count
			WHERE Id = @id;
		END

	--PRINT 'Decreased value of Count for tag: ' + @id;
--GO