USE [master]
GO
/****** Object:  Database [ToDoItemDb]    Script Date: 15-02-2024 19:28:58 ******/
CREATE DATABASE [ToDoItemDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoItemDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ToDoItemDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToDoItemDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ToDoItemDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ToDoItemDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToDoItemDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToDoItemDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToDoItemDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToDoItemDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToDoItemDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToDoItemDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToDoItemDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ToDoItemDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToDoItemDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToDoItemDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToDoItemDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToDoItemDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToDoItemDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToDoItemDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToDoItemDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToDoItemDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ToDoItemDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToDoItemDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToDoItemDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToDoItemDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToDoItemDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToDoItemDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ToDoItemDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToDoItemDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToDoItemDb] SET  MULTI_USER 
GO
ALTER DATABASE [ToDoItemDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToDoItemDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToDoItemDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToDoItemDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToDoItemDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToDoItemDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ToDoItemDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [ToDoItemDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ToDoItemDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 15-02-2024 19:28:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToDoItems]    Script Date: 15-02-2024 19:28:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToDoItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Task] [nvarchar](100) NOT NULL,
	[IsCompleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ToDoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202402150428580_InitialCreate', N'ToDoApp.Models.ToDoItemContext', 0x1F8B0800000000000400CD57CD6EDB3810BE2FB0EF20E89C9A4E726903B9456A270BA37512546EEF6369EC10A5482D4905F6B3F5B08FB4AFB043EBD794ED3869512C7289C899E1371FE79BA1FFFDF14FF4619D89E009B5E14A8EC2F3C1300C50262AE572350A0BBB7CF336FCF0FECF3FA29B345B07DF6ABB4B67479ED28CC2476BF32BC64CF288199841C613AD8C5ADA41A23206A96217C3E13B767ECE904284142B08A22F85B43CC3ED077D8E954C30B70588994A51986A9D76E26DD4E00E32343924380AE76AA2AEF37C505A86C1B5E040286214CB30002995054B18AFBE1A8CAD567215E7B40062BEC991EC96200C56D8AF5AF353D3185EB83458EB58874A0A6355F6C280E797152FCC777F15BB61C31B3177430CDB8DCB7ACB5E49DCD4621606FE615763A19DA14FEEA076390BAA8DB3A604A852DCDF59302E842D348E24165683380B1E8A85E0C927DCCCD57794235908D10546D0686F6781961EB4CA51DBCD175C5670A76918B05D3FE63B366E1D9F3291A9B4971761704787C3426073EF9DA463AB34FE851235584C1FC05AD4D2C5C02D73BDD3BDB3E660BED7A751A1915EC26006EBCF2857F69194342485DCF235A6F54A85E0ABE4242F72B2BAC03D088F9F3A356395E50209717DF847A504827C2654C4DA82E8970909D002272ABC5A71EBB8B67B4A86E455558DA952D9C55DC68DD17A1149B12D9052B683B632F7216EB0B55D81956DA16E1FEC40FF886690E774319D7E52AD0471D94CC66FE2972B2D2B63B0C4EC115C83B63989CA0C56E8EDD2D184F4966B6327606101EEBEC669D633F36FE200CBF5693ED9BECE5AEE6B0FF77FEBB547FC7E8C96C55B4A2C23B56C73C4064BA7D5F45CB72D1D04E83DCA1D2B5164F290FA8F79975AECFA972BA747D8D1D50E90EE463F5EC43C2E7CC2598F71AFA7F957784C01BE49737AA304AFE2A3AAFA9E1FABBD722C4DC280887AE2A92BC57863E84E07CE6010FF2DC68253BEADC10C245FA2B165DB0F69BA5D78D3F9FF33299931A938715CFEF6D9C51DABCF4EA7170E8EEEB8924FA09347D0FD81F5F3D368C1ED2F9D44FD3679DA9C393A66CADA1E85E94211EE12696740BD720AF5B516B1EE43379AA0E1AB36847BF64A4C5C11B7416B9BA95CAA9A6DCAAE8BA836F12E6386165222E95A5BBE84C4D27682C66C1F26DF40146472932D309DCAFBC2E685BD3606B385D879E844ECF8F9DB51BB8B39BACFDD97F91529104C4E29E0BDFC58709136B86FF754D18110AE5E2AD9102A7A9851B8D5A68974A7E489812AFA2698A374A29B23553A0533F73286277C0D367A337DC615249BBA651E0EF2FC45ECD21E4D38AC3464A68AD1FABB1F6FCCFD7A7BFF1F0EF31867EF0D0000, N'6.4.4')
GO
SET IDENTITY_INSERT [dbo].[ToDoItems] ON 

INSERT [dbo].[ToDoItems] ([Id], [Task], [IsCompleted]) VALUES (4, N'Task4', 0)
INSERT [dbo].[ToDoItems] ([Id], [Task], [IsCompleted]) VALUES (5, N'Task4', 1)
INSERT [dbo].[ToDoItems] ([Id], [Task], [IsCompleted]) VALUES (8, N'New Task', 1)
INSERT [dbo].[ToDoItems] ([Id], [Task], [IsCompleted]) VALUES (10, N'Task6', 0)
INSERT [dbo].[ToDoItems] ([Id], [Task], [IsCompleted]) VALUES (11, N'task7', 1)
SET IDENTITY_INSERT [dbo].[ToDoItems] OFF
GO
USE [master]
GO
ALTER DATABASE [ToDoItemDb] SET  READ_WRITE 
GO
