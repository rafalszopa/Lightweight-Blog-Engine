-- Delete all data from Integration Test Database

USE [Blog.IntegrationTests]
--GO

-- Drop all tables
IF OBJECT_ID('Post_Tag') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Post_Tag]
END

IF OBJECT_ID('PostDetails') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[PostDetails]
END

IF OBJECT_ID('Posts') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Posts]
END

IF OBJECT_ID('PostStatuses') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[PostStatuses]
END

IF OBJECT_ID('Tags') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Tags]
END

IF OBJECT_ID('Users') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Users]
END

IF OBJECT_ID('UserTypes') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[UserTypes]
END

IF OBJECT_ID('Post_Tag') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Post_Tag]
END

-- Create new tables
CREATE TABLE [dbo].[UserTypes](
	[UserTypeId]	int IDENTITY(1,1)	NOT NULL,
	[Type]			varchar(20)			NOT NULL,
	PRIMARY KEY CLUSTERED ([UserTypeId] ASC)
)

CREATE TABLE [dbo].[Users](
	[Id]			int IDENTITY(1,1)	NOT NULL,
	[FirstName]		varchar(20)			NOT NULL,
	[LastName]		varchar(20)			NOT NULL,
	[Email]			varchar(30)			NOT NULL,
	[Bio]			varchar(100)		NULL,
	[CreateDate]	datetime			NOT NULL,
	[UserTypeId]	int					NOT NULL,
	[IsActive]		bit					NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY ([UserTypeId]) REFERENCES [dbo].[UserTypes]([UserTypeId])
)

CREATE TABLE [dbo].[Tags](
	[Name]			varchar(20)			NOT NULL PRIMARY KEY,
	[Count]			int					NOT NULL
	--PRIMARY KEY CLUSTERED ([Name] ASC)
)

CREATE TABLE [dbo].[PostStatuses](
	[PostStatusId]	int IDENTITY(1,1)	NOT NULL,
	[Status]		varchar(20)			NOT NULL,
	PRIMARY KEY CLUSTERED ([PostStatusId] ASC)
)

CREATE TABLE [dbo].[Posts](
	[Id]			int IDENTITY(1,1)	NOT NULL,
	[Title]			varchar(300)		NOT NULL,
	[Description]	varchar(500)		NOT NULL,
	[CreateDate]	datetime			NOT NULL,
	[PublishDate]	datetime			NULL,
	[PhotoUrl]		varchar(50)			NULL,
	[UserId]		int					NOT NULL,
	[StatusId]		int					NOT NULL
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Posts_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id]),
	CONSTRAINT [FK_Posts_PostStatuses] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[PostStatuses]([PostStatusId])
)

CREATE TABLE [dbo].[PostDetails](
	[PostId]		int					NOT NULL,
	[Content]		text				NULL,
	CONSTRAINT [FK_PostsDetails_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts]([Id]),
)

CREATE TABLE [dbo].[Post_Tag](
	[PostId]		int					NOT NULL,
	[Tag]			varchar(20)			NOT NULL,
	CONSTRAINT [FK_Posts_Tags_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts]([Id]),
	CONSTRAINT [FK_Posts_Tags_Tag] FOREIGN KEY ([Tag]) REFERENCES [dbo].[Tags]([Name]),
	CONSTRAINT [UQ_codes] UNIQUE NONCLUSTERED([PostId], [Tag])
)