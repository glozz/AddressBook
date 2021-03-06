USE [master]
GO
/****** Object:  Database [AddressBook]    Script Date: 5/13/2019 2:09:07 AM ******/
CREATE DATABASE [AddressBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AddressBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LOCALDB\MSSQL\DATA\AddressBook.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AddressBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LOCALDB\MSSQL\DATA\AddressBook_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AddressBook] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AddressBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AddressBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AddressBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AddressBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AddressBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AddressBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [AddressBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AddressBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AddressBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AddressBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AddressBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AddressBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AddressBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AddressBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AddressBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AddressBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AddressBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AddressBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AddressBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AddressBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AddressBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AddressBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AddressBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AddressBook] SET RECOVERY FULL 
GO
ALTER DATABASE [AddressBook] SET  MULTI_USER 
GO
ALTER DATABASE [AddressBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AddressBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AddressBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AddressBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AddressBook] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AddressBook', N'ON'
GO
USE [AddressBook]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/13/2019 2:09:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[ContactNumber] [nvarchar](20) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email]    Script Date: 5/13/2019 2:09:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mapping]    Script Date: 5/13/2019 2:09:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mapping](
	[MappingId] [int] IDENTITY(1,1) NOT NULL,
	[MainUserId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Mapping] PRIMARY KEY CLUSTERED 
(
	[MappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 5/13/2019 2:09:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (1, N'0811728452', 19)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (2, N'0712544355', 20)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (6, N'0714533511', 19)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (7, N'0841425100', 20)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (12, N'011412241', 19)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (13, N'084923333', 20)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (14, N'084923333', 20)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (16, N'0667284566', 19)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (19, N'021440011', 19)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (21, N'0849283653', 25)
INSERT [dbo].[Contact] ([ContactId], [ContactNumber], [UserId]) VALUES (22, N'512121', 19)
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[Email] ON 

INSERT [dbo].[Email] ([EmailId], [EmailAddress], [UserId]) VALUES (1004, N'GGloucester@gmail.com', 19)
INSERT [dbo].[Email] ([EmailId], [EmailAddress], [UserId]) VALUES (1005, N'ITu@gmail.com', 20)
INSERT [dbo].[Email] ([EmailId], [EmailAddress], [UserId]) VALUES (1009, N'esromglozz@gmail', 19)
INSERT [dbo].[Email] ([EmailId], [EmailAddress], [UserId]) VALUES (1011, N'esromglozz@gmail.com', 25)
SET IDENTITY_INSERT [dbo].[Email] OFF
SET IDENTITY_INSERT [dbo].[Mapping] ON 

INSERT [dbo].[Mapping] ([MappingId], [MainUserId], [UserId]) VALUES (1002, 1, 19)
INSERT [dbo].[Mapping] ([MappingId], [MainUserId], [UserId]) VALUES (1003, 1, 20)
INSERT [dbo].[Mapping] ([MappingId], [MainUserId], [UserId]) VALUES (1006, 1, 23)
INSERT [dbo].[Mapping] ([MappingId], [MainUserId], [UserId]) VALUES (1008, 1, 25)
SET IDENTITY_INSERT [dbo].[Mapping] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Address]) VALUES (1, N'Gloucester', N'Mafokoane', N'25 Voortrekker Rd Bellville, Boston')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Address]) VALUES (19, N'Ntshetse', N'Mafokoane', N'25 Paledi Rd')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Address]) VALUES (20, N'Itumeleng1', N'Ramabula', N'12 Nobody rd')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Address]) VALUES (23, N'Gloucester', N'Maluleka', N'25 voortrekker road Bellville, Boston')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Address]) VALUES (25, N'Gloucester', N'MAFOKOANE', N'25 voortrekker road Bellville, Boston')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_User]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_User]
GO
ALTER TABLE [dbo].[Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Mapping_User] FOREIGN KEY([MainUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Mapping] CHECK CONSTRAINT [FK_Mapping_User]
GO
USE [master]
GO
ALTER DATABASE [AddressBook] SET  READ_WRITE 
GO
