USE [master]
GO
CREATE DATABASE [Library]
Go
USE [Library]
GO
CREATE TABLE [Users]
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nickname NVARCHAR(50) NOT NULL,
	[Password] CHAR(97) NOT NULL
)
GO
CREATE TABLE [Books]
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Isbn VARCHAR(17) UNIQUE NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Genre] NVARCHAR(50),
	[Description] NVARCHAR(1000),
	[Author] NVARCHAR(100) NOT NULL,
	[ReceiptTime] DATETIME,
	ReturnTime DATETIME
)

INSERT INTO [Users] (Nickname, [Password])
VALUES
(
	'user',
	'E24FECBB80B33722CDFF42A63635555F2E1EAB5AC9F7FB28BA07F61A3D29DF27:D0AB4E3D13A15CE460D6D7AD14E7DBAD'
),
(
	'teacher',
	'876D3217CF513A3DBB02FF508FDB5CB2CA73BC3D693C443AB58D650A15999091:848EBCA5921031993602CA04FDE369AE'
);

INSERT INTO [Books] (Isbn, [Name], [Genre], [Description], [Author])
VALUES
(
	'978-0-7352-1128-5',
	'The Lincoln Highway',
	'historical fiction',
	'This is a historical fiction novel that follows four young men on a cross-country road trip in 1950s America. Along the way, they encounter adventure, danger, and unexpected connections.',
	'Amor Towles'
),
(
	'978-0-4417-8644-5',
	'Dune',
	'science fiction',
	'This is a science fiction classic that tells the story of Paul Atreides, a young man who inherits a desert planet called Arrakis, which holds a valuable spice that can extend life and enhance consciousness. Paul must fight against enemies who want to take over his planet and his destiny.',
	'Frank Herbert'
),
(
	'978-0-7352-1049-3',
	'Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones',
	'self-help',
	'This is a self-help book that teaches readers how to create and maintain effective habits that can improve their lives. The book draws on scientific research, personal stories, and practical advice.',
	'James Clear'
)