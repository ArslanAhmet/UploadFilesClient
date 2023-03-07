USE [AsyaLogic]
GO

/****** Object:  Table [dbo].[RecordColumnChanges]    Script Date: 3/6/2023 7:18:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecordColumnChanges](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[Name] [nchar](100) NULL,
	[Value] [nchar](100) NULL,
	[PointInTime] [bigint] NULL,
 CONSTRAINT [PK_RecordColumnChanges] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


