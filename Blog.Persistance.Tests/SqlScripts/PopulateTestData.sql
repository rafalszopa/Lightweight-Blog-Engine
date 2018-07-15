-- Populate Integration Test Database with test data

USE [Blog.IntegrationTests]
--GO

INSERT [dbo].[UserTypes] (Type) VALUES 
('Admin'),
('Author')

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Admin', 'Admin', 'admin@admin.com', 'Superuser', '2001-01-01 00:00:00', 1, 1)

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Nikola', 'Tesla', 'nikola@tesla.com', 'Electrical engineer and inventor', '2018-07-13 00:00:00', 2, 1)

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Albert', 'Einstein', 'albert@einstein.com', 'German born theoretical physicist', '2001-01-01 00:00:00', 2, 1)

INSERT [dbo].[Users] (FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive) VALUES
('Rafał', 'Szopa', 'rafalszopa.92@gmail.com', 'Fullstack developer in love in design', '2017-03-30 00:00:00', 2, 1)

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

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('what-if-kim-jong-un-wants-peace',
'What if Kim Jong-Un wants peace?',
'We’ll deliver the best stories and ideas on the topics you care about most straight to your homepage, app, or inbox.',
'2018-05-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
2,
2,
1)

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

INSERT INTO [dbo].[Posts] (Slug,Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('a-really-bad-month',
'A Really Bad Month',
'The legal industry needs to come to terms with its gender bias, unconscious or not',
'2000-02-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
3,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(2, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('how-i-become-talking-head',
'How I became talking head',
'I don’t ever network, 28-year-old criminal defense attorney Nicole Fegan',
'2000-02-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
4,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(3, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('24-book-club-the-bitcoin-standard-part-1---critical-review',
'#24: Book Club: “The Bitcoin Standard” (Part 1) - critical review',
'A journey into Reality L.A., Hollywood’s hippest evangelical church',
'2000-02-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
4,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(4, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('web-architecture-101',
'Web Architecture 101',
'The basic architecture concepts I wish I knew when I was getting started as a web developer',
'2000-02-20 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
2,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(5, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('the-open-plan-office-is-a-terrible-horrible-no-good-very-bad-idea',
'The open-plan office is a terrible, horrible, no good, very bad idea',
'And it’s these managers who are in charge of designing office layouts and signing leases.',
'2017-03-30 02:00:00',
'2018-05-20 02:00:00',
'content/232/photo.jpg',
3,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(6, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('the-things-men-wish-they-knew-before-they-got-marrie',
'The Things Men Wish They Knew Before They Got Married',
'Every wedding season — such as, you know, RIGHT NOW',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
4,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(7, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('with-regulators-wary-facebook-is-poring-over-its-prize-asset-your-face',
'With Regulators Wary, Facebook Is Poring Over Its Prize Asset: Your Face',
'Facebook is working to spread its face-matching tools even as it faces heightened scrutiny from regulators and legislators in Europe and North America',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
2,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(8, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('magic-pills-machine-learning-skincare-and-the-future',
'Magic Pills, Machine-Leaning Skincare, and the Future...',
'Eight new trends that are revolutionizing...',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
3,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(9, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('the-open-plan-office-is-a-terrible-horrible-no-good-very-bad-idea',
'The open-plan office is a terrible, horrible, no good, very bad idea',
'Not because there aren’t people who actually enjoy working in an open office, there are.',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
3,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(10, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('we-have-a-podcast-meet-the-host',
'We Have a Podcast! Meet the Hosts',
'Kara Brown and Manoush Zomorodi discuss the power of voice, their favorite books, and fancy pasta',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
2,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(11, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('women-dont-speak-a-different-language',
'Women Don’t Speak a Different Language',
'Why you can’t blame gender for your communication problems',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
4,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(12, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('how--i-fully-quit-google-and-you-can-too',
'How I Fully Quit Google (And You Can, Too)',
'My enlightening quest to break free of a tech giant',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
4,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(13, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('what-will-we-look-like-in-100-years',
'What Will We Look Like in 100 Years',
'It’s good or bad, depending on who you ask',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
3,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(14, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('this-is-how-normal-life-feels-as-a-psychopath',
'This Is How Normal Life Feels as a Psychopath',
'Everyday, nonviolent psychopaths say they’re nothing like the psychopath we see on our movie screens',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
4,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(15, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('its-boom-time-for-death-cults',
'It’s Boom Time for Death Cults',
'Three very different mortality movements are surging in popularity across the death-denying West',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
2,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(16, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Posts] (Slug, Title, Description, CreateDate, PublishDate, PhotoUrl, UserId, StatusId, IsActive) VALUES 
('meet-ms-got-proof-the-lebron-james-of-the-legal-world',
'Meet Ms. Got Proof, the Lebron James of the Legal World',
'Atlanta attorney Nicole Fegan is changing the gamet',
'2000-02-20 02:00:00',
'2014-05-22 02:00:00',
'content/232/photo.jpg',
2,
2,
1);

INSERT INTO [dbo].[PostDetails] (PostId, Content, Type) VALUES
(17, '<h1>Hello world</h1>', 1);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 1);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 2);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 3);

INSERT INTO [dbo].[Post_Tag] (PostId, TagId) VALUES
(1, 4);
