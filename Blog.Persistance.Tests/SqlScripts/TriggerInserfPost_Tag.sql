-- Triggers
CREATE TRIGGER triggerAfterInsertOfPost_Tag ON [dbo].[Post_Tag] 
FOR INSERT
AS
	DECLARE @tag varchar(20);
	DECLARE @count int;

	SELECT @tag = i.Tag from inserted i;
	SELECT @count = tags.Count from [dbo].[Tags] tags where Name = @tag;
	
	SET @count = @count + 1; -- Increase 'Count' value after new value is inserted into Post_Tag table'

	UPDATE [dbo].[Tags]
	SET Count = @count
	WHERE Name = @tag;

	PRINT 'Increased value of Count for tag: ' + @tag;
--GO