USE [Locations]
GO

/****** Object:  Table [dbo].[PeopleAddresses]    Script Date: 3/31/2022 4:04:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PeopleAddresses](
	[ID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NULL,
	[AddressID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PeopleAddresses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PeopleAddresses] ADD  DEFAULT (newid()) FOR [ID]
GO


