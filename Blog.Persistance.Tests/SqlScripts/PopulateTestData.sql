-- Populate Integration Test Database with test data

USE [Blog.IntegrationTests]
--GO

INSERT [dbo].[UserTypes] (Type) VALUES 
('Admin'),
('Author')

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Nikola', 'Tesla', 'nikola@tesla.com', 'Electrical engineer and inventor', '2000-01-01 00:00:00', 2, 1)

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Albert', 'Einstein', 'albert@einstein.com', 'German born theoretical physicist', '2001-01-01 00:00:00', 2, 1)

INSERT [dbo].[PostStatuses] (Status) VALUES 
('Live'),
('Draft'),
('Hidden'),
('Obsolete'),
('Deleted')

INSERT [dbo].[Tags] (Name, Count) VALUES 
('programming', 0);

INSERT [dbo].[Tags] (Name, Count) VALUES 
('vue.js', 0);

INSERT [dbo].[Tags] (Name, Count) VALUES 
('javascript', 0);

INSERT [dbo].[Tags] (Name, Count) VALUES 
('agile', 0);

INSERT INTO [dbo].[Posts] (Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId) VALUES 
('What if Kim Jong-Un wants peace?',
'We’ll deliver the best stories and ideas on the topics you care about most straight to your homepage, app, or inbox.',
'2018-05-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
1,
2)

INSERT INTO [dbo].[PostDetails] (PostId, Content) VALUES
(1, '<div class="content">This is some examplary content.</div>')

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 1);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 2);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 3);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 4);
