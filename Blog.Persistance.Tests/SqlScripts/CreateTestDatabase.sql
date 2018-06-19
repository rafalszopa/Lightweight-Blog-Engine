USE master;

-- Drop database only for development process
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Blog.IntegrationTests')
BEGIN
	DROP DATABASE [Blog.IntegrationTests]
END

CREATE DATABASE [Blog.IntegrationTests]

GO