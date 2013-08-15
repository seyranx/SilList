CREATE TABLE [data].[JobCompany] (
    [jobCompanyId] UNIQUEIDENTIFIER NOT NULL,
    [name]         NVARCHAR (50)    NULL,
    [address]      NVARCHAR (50)    NULL,
    [city]         NVARCHAR (50)    NULL,
    [state]        NVARCHAR (50)    NULL,
    [zip]          INT              NULL,
    [website]      NVARCHAR (50)    NULL,
    [phone]        NVARCHAR (50)    NULL,
    [siteId]       NCHAR (10)       NULL,
    [created]      DATETIME         CONSTRAINT [DF__JobCompan__creat__236943A5] DEFAULT (getdate()) NOT NULL,
    [modified]     DATETIME         CONSTRAINT [DF__JobCompan__modif__245D67DE] DEFAULT (getdate()) NOT NULL,
    [createdBy]    INT              NULL,
    [modifiedBy]   INT              NULL,
    [isActive]     BIT              NOT NULL DEFAULT ((1)),
    CONSTRAINT [PK__JobCompa__A2D2B0051CF0B5EC] PRIMARY KEY CLUSTERED ([jobCompanyId] ASC)
);



