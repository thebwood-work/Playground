USE [IdentityAndSecurity]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 3/10/2022 11:02:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[ID] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[PasswordHash][varbinary](200) NOT NULL,
	[PasswordSalt][varbinary](200) NOT NULL,
	[IsDeleted][bit] NOT NULL,
	[CreatedBy][varchar](50) NULL,
	[CreatedAt][DateTime] NULL,
	[Email][varchar](200) NULL,


 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [ID]
GO


