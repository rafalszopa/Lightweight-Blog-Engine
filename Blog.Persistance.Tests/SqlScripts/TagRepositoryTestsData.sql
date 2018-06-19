-- Populate test data for TagRepositoryTests integration tests

USE [Blog.IntegrationTests]

INSERT [dbo].[Tags] (Name, Count) VALUES 
('tag1', 1);

INSERT [dbo].[Tags] (Name, Count) VALUES 
('tag2', 2);

INSERT [dbo].[Tags] (Name, Count) VALUES 
('tag3', 3);

INSERT [dbo].[UserTypes] (Type) VALUES 
('Admin');

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId) VALUES
('Nikola', 'Tesla', 'nikola@tesla.com', 'Electrical engineer and inventor', '2000-01-01 00:00:00', 1);

INSERT [dbo].[PostStatuses] (Status) VALUES 
('Live');

INSERT INTO [dbo].[Posts] (Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId) VALUES 
('What if Kim Jong-Un wants peace?',
'We’ll deliver the best stories and ideas on the topics you care about most straight to your homepage, app, or inbox.',
'2018-05-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
1,
1)

INSERT INTO [dbo].[Post_Tag] (PostId, Tag) VALUES
(1, 'tag1');

INSERT INTO [dbo].[Post_Tag] (PostId, Tag) VALUES
(1, 'tag2');