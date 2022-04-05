USE [IdentityAndSecurity]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 3/10/2022 11:02:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles](
	[ID] [uniqueidentifier] NOT NULL,
	[RoleName][varchar](50) NOT NULL,
	[IsDeleted][bit] NULL,
	[CreatedAt][DateTime] NULL,
	[CreatedBy][varchar](50) NULL,

 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Roles] ADD  DEFAULT (newid()) FOR [ID]
GO


