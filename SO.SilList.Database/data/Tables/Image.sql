CREATE TABLE [data].[Image](
	[imageId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[name] [nvarchar](50) NULL,
	[url] [nvarchar](50) NULL,
	[path] [nvarchar](50) NULL,
	[fileType] [nvarchar](50) NULL,
	[siteId] [int] NULL,
	[height] [int] NULL,
	[width] [int] NULL,
	[size] [int] NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL,
	[createdBy] [int] NULL,
	[modifiedBy] [int] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[imageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [data].[Image] ADD  CONSTRAINT [DF_Image_imageId]  DEFAULT (newid()) FOR [imageId]
GO
ALTER TABLE [data].[Image] ADD  CONSTRAINT [DF_Image_created]  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [data].[Image] ADD  CONSTRAINT [DF_Image_modified]  DEFAULT (getdate()) FOR [modified]