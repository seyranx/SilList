CREATE TABLE [data].[Image] (
    [imageId]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [name]       NVARCHAR (50)    NULL,
    [url]        NVARCHAR (50)    NULL,
    [path]       NVARCHAR (50)    NULL,
    [fileType]   NVARCHAR (50)    NULL,
    [siteId]     INT              NULL,
    [height]     INT              NULL,
    [width]      INT              NULL,
    [size]       INT              NULL,
    [created]    DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED ([imageId] ASC)
);



