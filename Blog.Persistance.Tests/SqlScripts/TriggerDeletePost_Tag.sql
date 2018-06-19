-- Triggers
-- TO DO: How to handle inserting multiple values?

CREATE TRIGGER triggerAfterDeleteOfPost_Tag ON [dbo].[Post_Tag] 
FOR DELETE
AS
	DECLARE @tag varchar(20);
	DECLARE @count int;

	SELECT @tag = i.Tag from deleted i;
	SELECT @count = tags.Count from [dbo].[Tags] tags where Name = @tag;
	
	SET @count = @count - 1; -- Decrease 'Count' value after value is deleted from Post_Tag table'
	PRINT 'Count: ' + STR(@count);
	IF @count = 0
		BEGIN
			DELETE FROM [dbo].[Tags]
			WHERE Name = @tag;
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Tags]
			SET Count = @count
			WHERE Name = @tag;
		END

	PRINT 'Decreased value of Count for tag: ' + @tag;
--GO