CREATE TABLE [app].[Site] (
    [siteId]      INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (250) NULL,
    [domain]      NVARCHAR (250) NULL,
    [description] NVARCHAR (MAX) NULL,
    [logo]        NVARCHAR (MAX) NULL,
    [logoUrl]     NVARCHAR (MAX) NULL,
    [created]     DATETIME       NOT NULL DEFAULT getdate(),
    [modified]    DATETIME       NOT NULL DEFAULT getdate(),
    [createdBy]   INT            NULL,
    [modifiedBy]  INT            NULL,
    [isActive]    BIT            NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED ([siteId] ASC)
);











