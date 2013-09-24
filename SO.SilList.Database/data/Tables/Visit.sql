CREATE TABLE [data].[Visit] (
    [visitId]     UNIQUEIDENTIFIER NOT NULL,
    [siteId]      INT              NOT NULL,
    [ipAddress]   VARCHAR (50)     NOT NULL,
    [referrerUrl] VARCHAR (MAX)    NULL,
    [browser]     VARCHAR (MAX)     NULL,
    [controller]  VARCHAR (50)     NOT NULL,
    [action]      VARCHAR (50)     NOT NULL,
    [visitCount]  INT              NOT NULL DEFAULT 1,
    [created]     DATETIME         NOT NULL DEFAULT (getdate()), 
    [modified]    DATETIME         NOT NULL DEFAULT (getdate())
    CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED ([visitId] ASC),
    CONSTRAINT [FK_Visit_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
);

