
use master
Create Database MasterMind
go
USE [Mastermind]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 22/05/2016 18:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [int] IDENTITY(1,1) NOT NULL,
	[GameSequence] [varchar](8) NULL,
	[Player_Games_StagesId1] [int] NULL,
	[Player_Games_StagesId2] [int] NULL,
	[Winner_UserId] [int] NULL,
	[Player_Name_1] [varchar](100) NULL,
	[Player_Name_2] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Games_Stages]    Script Date: 22/05/2016 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games_Stages](
	[Games_StagesId] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NULL,
	[StageId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Games_StagesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Stages]    Script Date: 22/05/2016 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stages](
	[StageId] [int] IDENTITY(1,1) NOT NULL,
	[PlayerSequence] [varchar](8) NULL,
	[StageCheck] [varchar](10) NULL,
	[IsMatch] [int] NULL,
	[UserId] [int] NULL,
	[GameId] [int] NULL,
	[StageCheck2] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[StageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/05/2016 18:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](255) NULL,
	[IsWaitChallenger] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
