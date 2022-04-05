USE [IdentityAndSecurity]
GO

/****** Object:  Table [dbo].[UserLogins]    Script Date: 3/10/2022 11:02:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserLogins](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Token] [varchar](500) NOT NULL,
	[LoginAt][DateTime] NULL,

 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserLogins] ADD  DEFAULT (newid()) FOR [ID]
GO


