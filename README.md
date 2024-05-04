# prueba_redarbor
 
Add script DB



CREATE DATABASE redarbor;



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Fax] [nvarchar](20) NULL,
	[Name] [nvarchar](100) NULL,
	[LastLogin] [datetime] NULL,
	[Password] [nvarchar](100) NOT NULL,
	[PortalId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Telephone] [nvarchar](20) NULL,
	[UpdatedOn] [datetime] NULL,
	[Username] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO




