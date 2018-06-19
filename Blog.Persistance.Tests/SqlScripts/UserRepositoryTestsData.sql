-- Populate test data for UserRepositoryTests integration tests

USE [Blog.IntegrationTests]

INSERT [dbo].[UserTypes] (Type) VALUES 
('Admin'),
('Author');

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Nikola', 'Tesla', 'nikola@tesla.com', 'Electrical engineer and inventor', '2000-01-01 00:00:00', 1, 1);

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Albert', 'Einstein', 'albert@einstein.com', 'German born theoretical physicist', '2001-01-01 00:00:00', 2, 1);