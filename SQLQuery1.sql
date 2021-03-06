USE [master]
GO
/****** Object:  Database [SchoolExhibition]    Script Date: 04-11-2019 03:27:18 PM ******/
CREATE DATABASE [SchoolExhibition]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolExhibition', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SchoolExhibition.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SchoolExhibition_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SchoolExhibition_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SchoolExhibition] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolExhibition].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolExhibition] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SchoolExhibition] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SchoolExhibition] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SchoolExhibition] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SchoolExhibition] SET ARITHABORT OFF 
GO
ALTER DATABASE [SchoolExhibition] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolExhibition] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolExhibition] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolExhibition] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolExhibition] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SchoolExhibition] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SchoolExhibition] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolExhibition] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SchoolExhibition] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolExhibition] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchoolExhibition] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolExhibition] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolExhibition] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolExhibition] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolExhibition] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolExhibition] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolExhibition] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolExhibition] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolExhibition] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolExhibition] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SchoolExhibition] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolExhibition] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolExhibition] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SchoolExhibition] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SchoolExhibition]
GO
/****** Object:  Table [dbo].[ClassMaster]    Script Date: 04-11-2019 03:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[NumberOfStudents] [int] NULL,
	[Section] [nvarchar](50) NULL,
 CONSTRAINT [PK_ClassMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExhibitionCoordinatorMaster]    Script Date: 04-11-2019 03:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExhibitionCoordinatorMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ExhibitionCoordinatorMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentMaster]    Script Date: 04-11-2019 03:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassMasterID] [int] NULL,
	[ExhibitionCoordinatorMasterID] [int] NULL,
	[StudentName] [nvarchar](50) NULL,
 CONSTRAINT [PK_StudentMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 04-11-2019 03:27:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ClassMaster] ON 

GO
INSERT [dbo].[ClassMaster] ([ID], [ClassName], [NumberOfStudents], [Section]) VALUES (1, N'1st', NULL, NULL)
GO
INSERT [dbo].[ClassMaster] ([ID], [ClassName], [NumberOfStudents], [Section]) VALUES (2, N'2nd', NULL, NULL)
GO
INSERT [dbo].[ClassMaster] ([ID], [ClassName], [NumberOfStudents], [Section]) VALUES (3, N'1st', 25, N'B')
GO
SET IDENTITY_INSERT [dbo].[ClassMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ExhibitionCoordinatorMaster] ON 

GO
INSERT [dbo].[ExhibitionCoordinatorMaster] ([ID], [Name]) VALUES (1, N'Nirmal')
GO
SET IDENTITY_INSERT [dbo].[ExhibitionCoordinatorMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentMaster] ON 

GO
INSERT [dbo].[StudentMaster] ([ID], [ClassMasterID], [ExhibitionCoordinatorMasterID], [StudentName]) VALUES (1, 1, 1, N'Kamal')
GO
SET IDENTITY_INSERT [dbo].[StudentMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

GO
INSERT [dbo].[UserMaster] ([ID], [UserName], [Password]) VALUES (1, N'Ishwer', N'Ishwer')
GO
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
ALTER TABLE [dbo].[StudentMaster]  WITH CHECK ADD  CONSTRAINT [FK_StudentMaster_ClassMaster] FOREIGN KEY([ClassMasterID])
REFERENCES [dbo].[ClassMaster] ([ID])
GO
ALTER TABLE [dbo].[StudentMaster] CHECK CONSTRAINT [FK_StudentMaster_ClassMaster]
GO
ALTER TABLE [dbo].[StudentMaster]  WITH CHECK ADD  CONSTRAINT [FK_StudentMaster_ExhibitionCoordinatorMaster] FOREIGN KEY([ExhibitionCoordinatorMasterID])
REFERENCES [dbo].[ExhibitionCoordinatorMaster] ([ID])
GO
ALTER TABLE [dbo].[StudentMaster] CHECK CONSTRAINT [FK_StudentMaster_ExhibitionCoordinatorMaster]
GO
USE [master]
GO
ALTER DATABASE [SchoolExhibition] SET  READ_WRITE 
GO
