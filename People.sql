USE [People]
GO

/****** Object:  Table [dbo].[People]    Script Date: 3/10/2022 11:03:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[People](
	[ID] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[BirthCity] [varchar](100) NULL,
	[BirthStateID] [uniqueidentifier] NULL,
	[City] [varchar](100) NULL,
	[StateID] [uniqueidentifier] NULL,
	[StateAbbreviation] [varchar](5) NULL,
	[StateName] [varchar](50) NULL,
	[CountryID] [uniqueidentifier] NULL,
	[CountryAbbreviation] [varchar](10) NULL,
	[CountryName] [varchar](50) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[People] ADD  DEFAULT (newid()) FOR [ID]
GO


