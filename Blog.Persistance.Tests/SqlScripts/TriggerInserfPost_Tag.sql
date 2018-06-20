-- Triggers
CREATE TRIGGER triggerAfterInsertOfPost_Tag ON [dbo].[Post_Tag] 
FOR INSERT
AS
	DECLARE @id		int;
	DECLARE @count	int;

	SELECT @id = i.TagId from inserted i;
	SELECT @count = tags.Count from [dbo].[Tags] tags where Id = @id;
	
	SET @count = @count + 1; -- Increase 'Count' value after new value is inserted into Post_Tag table'

	UPDATE [dbo].[Tags]
	SET Count = @count
	WHERE Id = @id;

	--PRINT 'Increased value of Count for tag: ' + @id;
--GO