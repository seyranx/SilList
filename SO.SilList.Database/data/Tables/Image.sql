CREATE TABLE [data].[Image](
	[imageId] UNIQUEIDENTIFIER NOT NULL DEFAULT newid() , 
	[name] [nvarchar](50) NULL,
	[url] [nvarchar](50) NULL,
	[path] [nvarchar](50) NULL,
	[fileType] [nvarchar](50) NULL,
	[siteId] [int] NULL,
	[height] [int] NULL,
	[width] [int] NULL,
	[size] [int] NULL,
	[created] [datetime] NOT NULL DEFAULT getdate(),
	[modified] [datetime] NOT NULL DEFAULT getdate(),
	[createdBy] [int] NULL,
	[modifiedBy] [int] NULL,
	[isActive] [bit] NULL DEFAULT 1,
-- generated from SSMS
-- CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 

    CONSTRAINT [PK_Image] PRIMARY KEY ([imageId])
)