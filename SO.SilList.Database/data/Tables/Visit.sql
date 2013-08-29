CREATE TABLE [dbo].[Visit]
(
	[visitId] UNIQUEIDENTIFIER NOT NULL,
	[siteId] INT NOT NULL,
    [ipAddress] VARCHAR(50) NOT NULL, 
    [referrerUrl] VARCHAR(MAX) NULL, 
    [visitTime] DATETIME NOT NULL DEFAULT (getdate()), 
    [browser] VARCHAR(50) NULL, 
    [controller] VARCHAR(50) NOT NULL, 
    [action] VARCHAR(50) NOT NULL,     
    CONSTRAINT [PK_Visit] PRIMARY KEY ([visitId]), 
    CONSTRAINT [FK_Visit_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
)
