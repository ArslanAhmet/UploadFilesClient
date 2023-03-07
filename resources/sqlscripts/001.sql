Create Database AsyaLogic

USE [AsyaLogic]
GO

/****** Object:  Table [dbo].[EventRecords]    Script Date: 3/6/2023 7:17:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventRecords](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[EventType] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[League] [nvarchar](100) NULL,
	[HomeTeam] [nvarchar](100) NULL,
	[AwayTeam] [nvarchar](100) NULL,
	[EventTime] [datetime2](7) NULL,
	[PointInTime] [bigint] NULL,
	[Created] [datetime2](7) NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


