USE [master]
GO
/****** Object:  Database [QuestionSystem]    Script Date: 20-02-2024 19:35:43 ******/
CREATE DATABASE [QuestionSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuestionSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QuestionSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuestionSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QuestionSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuestionSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuestionSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuestionSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuestionSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuestionSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuestionSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuestionSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuestionSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuestionSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuestionSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuestionSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuestionSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuestionSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuestionSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuestionSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuestionSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuestionSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuestionSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuestionSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuestionSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuestionSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuestionSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuestionSystem] SET  MULTI_USER 
GO
ALTER DATABASE [QuestionSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuestionSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuestionSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuestionSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuestionSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuestionSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuestionSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuestionSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuestionSystem]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 20-02-2024 19:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[ansId] [int] IDENTITY(1,1) NOT NULL,
	[paperId] [int] NULL,
	[userId] [int] NULL,
	[score] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ansId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 20-02-2024 19:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[queId] [int] IDENTITY(1,1) NOT NULL,
	[question] [nvarchar](max) NOT NULL,
	[opt1] [nvarchar](50) NOT NULL,
	[opt2] [nvarchar](50) NOT NULL,
	[opt3] [nvarchar](50) NOT NULL,
	[opt4] [nvarchar](50) NOT NULL,
	[answer] [nvarchar](50) NOT NULL,
	[paperId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[queId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionsPaper]    Script Date: 20-02-2024 19:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionsPaper](
	[paperId] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[noOfQuestions] [int] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[creation_date] [datetime] NULL,
	[userId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[paperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20-02-2024 19:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[role] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([ansId], [paperId], [userId], [score]) VALUES (1, 14, 5, 1)
INSERT [dbo].[Answer] ([ansId], [paperId], [userId], [score]) VALUES (2, 15, 5, 2)
INSERT [dbo].[Answer] ([ansId], [paperId], [userId], [score]) VALUES (1028, 14, 5, 0)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([queId], [question], [opt1], [opt2], [opt3], [opt4], [answer], [paperId]) VALUES (17, N'Question1', N'op1', N'op2', N'op3', N'op4', N'op1', 14)
INSERT [dbo].[Questions] ([queId], [question], [opt1], [opt2], [opt3], [opt4], [answer], [paperId]) VALUES (18, N'Question2', N'op1', N'op2', N'op3', N'op4', N'op2', 14)
INSERT [dbo].[Questions] ([queId], [question], [opt1], [opt2], [opt3], [opt4], [answer], [paperId]) VALUES (19, N'Question 1', N'option 1', N'option 2', N'option 3', N'option 4', N'option 1', 15)
INSERT [dbo].[Questions] ([queId], [question], [opt1], [opt2], [opt3], [opt4], [answer], [paperId]) VALUES (20, N'Question 2', N'option 1', N'option 2', N'option 3', N'option 4', N'option 2', 15)
INSERT [dbo].[Questions] ([queId], [question], [opt1], [opt2], [opt3], [opt4], [answer], [paperId]) VALUES (21, N'Question 3', N'option 1', N'option 2', N'option 3', N'option 4', N'option 4', 15)
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[QuestionsPaper] ON 

INSERT [dbo].[QuestionsPaper] ([paperId], [title], [description], [noOfQuestions], [status], [creation_date], [userId]) VALUES (14, N'test', N'Test paper', 2, N'approved', CAST(N'2024-02-20T10:47:48.000' AS DateTime), 9)
INSERT [dbo].[QuestionsPaper] ([paperId], [title], [description], [noOfQuestions], [status], [creation_date], [userId]) VALUES (15, N'Test paper', N'Exam', 3, N'approved', CAST(N'2024-02-20T14:25:18.000' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[QuestionsPaper] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [email], [password], [role]) VALUES (1, N'haresh', N'haresh@gmail.com', N'123', N'admin')
INSERT [dbo].[Users] ([id], [name], [email], [password], [role]) VALUES (5, N'hari', N'hari@gmail.com', N'123', N'student')
INSERT [dbo].[Users] ([id], [name], [email], [password], [role]) VALUES (9, N'harry', N'harry@gmail.com', N'123', N'teacher')
INSERT [dbo].[Users] ([id], [name], [email], [password], [role]) VALUES (10, N'teacher', N'teacher@gmail.com', N'123', N'teacher')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[QuestionsPaper] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[QuestionsPaper] ADD  DEFAULT (getdate()) FOR [creation_date]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('student') FOR [role]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([paperId])
REFERENCES [dbo].[QuestionsPaper] ([paperId])
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD FOREIGN KEY([paperId])
REFERENCES [dbo].[QuestionsPaper] ([paperId])
GO
ALTER TABLE [dbo].[QuestionsPaper]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[QuestionsPaper]  WITH CHECK ADD CHECK  (([noOfQuestions]<=(10)))
GO
ALTER TABLE [dbo].[QuestionsPaper]  WITH CHECK ADD  CONSTRAINT [CK_Status] CHECK  (([status]='rejected' OR [status]='pending' OR [status]='approved'))
GO
ALTER TABLE [dbo].[QuestionsPaper] CHECK CONSTRAINT [CK_Status]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Role] CHECK  (([role]='teacher' OR [role]='admin' OR [role]='student'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Role]
GO
USE [master]
GO
ALTER DATABASE [QuestionSystem] SET  READ_WRITE 
GO
