USE [Locations]
GO

/****** Object:  Table [dbo].[Countries]    Script Date: 3/10/2022 11:02:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Countries](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Countries] ADD  DEFAULT (newid()) FOR [ID]
GO


