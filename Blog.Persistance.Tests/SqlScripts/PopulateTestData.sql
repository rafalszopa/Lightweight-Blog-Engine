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

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(1,
'<div class="row">
        <div class="col-12">
            <section class="page">
                <header>
                    <h1 class="page__header">About<br>me</h1>
                </header>
                <article class="page__article">
                    <h2 class="page__headline">
                        What is the
                        <span class="page__headline--bold">point</span>?
                    </h2>
                    <p class="page__paragraph">
                        But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you
                        a complete account of the system, and expound the actual teachings of the great explorer
                        of the truth, the master-builder of human happiness.
                    </p>

                    <ul class="list">
                        <li class="list__item"><a class="page__link" href="/">JavaScript</a></li>
                        <li class="list__item"><a class="page__link" href="/">Vue.js</a></li>
                        <li class="list__item"><a class="page__link" href="/">.NET</a></li>
                        <li class="list__item"><a class="page__link" href="/">C#</a></li>
                        <li class="list__item"><a class="page__link" href="/">SQL</a></li>
                        <li class="list__item"><a class="page__link" href="/">UI/UX</a></li>
                    </ul>
                </article>
            </section>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <div class="image personal-image">
                <img class="personal-image__avatar" src="/images/avatar.jpg" />
            </div>
        </div>
        <div class="col-8">
            <h2 class="page__headline">
                <span class="page__headline--bold">Hello</span>, there!
            </h2>
            <p class="page__paragraph page__paragraph--small-margin">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                sed do eiusmod tempor incididunt ut labore et. Lorem ipsum dolor sit.
            </p>
            <ul class="social-media-list">
                <li class="social-media-list__item social-media-list__item--first">
                    <a href=""><img class="social-media-list__icon" src="~/images/github.png" /></a>
                </li>
                <li class="social-media-list__item">
                    <a href=""><img class="social-media-list__icon" src="~/images/codepen.png" /></a>
                </li>
                <li class="social-media-list__item">
                    <a href=""><img class="social-media-list__icon" src="~/images/twitter.png" /></a>
                </li>
                <li class="social-media-list__item">
                    <a href=""><img class="social-media-list__icon" src="~/images/linkedin.png" /></a>
                </li>
                <li class="social-media-list__item">
                    <a href=""><img class="social-media-list__icon" src="~/images/resume.png" /></a>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <p class="page__paragraph">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquipvoluptate velit esse cillum.
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                Don’t hesitate to <a class="page__link" href="/">say hello</a>!
            </p>
            <div class="center">
                <a class="button" href="/">Say hello!</a>
            </div>
        </div>
    </div>'
, 1)

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 1);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 2);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 3);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 4);
