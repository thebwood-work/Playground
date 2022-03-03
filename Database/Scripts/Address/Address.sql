USE [Address]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 3/2/2022 10:57:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Address](
	[ID] [uniqueidentifier] NOT NULL,
	[StreetNumber] [varchar](50) NULL,
	[StreetName] [varchar](100) NULL,
	[ApartmentNumber][varchar](50) NULL,
	[City] [varchar](100) NULL,
	[StateID] [uniqueidentifier] NULL,
	[StateAbbreviation] [varchar](5) NULL,
	[StateName] [varchar](50) NULL,
	[ZipCode] [varchar](20) NULL,
	[CountryId] [uniqueidentifier] NULL,
	[CountryAbbreviation] [varchar](10) NULL,
	[CountryName] [varchar](50) NULL,
	
CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Address] ADD  DEFAULT (newid()) FOR [ID]
GO
