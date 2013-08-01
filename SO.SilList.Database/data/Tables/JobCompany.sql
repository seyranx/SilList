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
    [created]      DATETIME         CONSTRAINT [DF__JobCompan__creat__236943A5] DEFAULT (getdate()) NULL,
    [modified]     DATETIME         CONSTRAINT [DF__JobCompan__modif__245D67DE] DEFAULT (getdate()) NULL,
    [createdBy]    INT              NOT NULL,
    [modifiedBy]   INT              NOT NULL,
    [isActive]     BIT              NULL,
    CONSTRAINT [PK__JobCompa__A2D2B0051CF0B5EC] PRIMARY KEY CLUSTERED ([jobCompanyId] ASC)
);



