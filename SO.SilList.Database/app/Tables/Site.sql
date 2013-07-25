CREATE TABLE [app].[Site] (
    [siteId] INT            NOT NULL,
    [name]   NVARCHAR (250) NULL,
    [domain] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED ([siteId] ASC)
);



