CREATE TABLE [data].[JobCompany] (
    [jobCompanyId] UNIQUEIDENTIFIER NOT NULL,
    [name]         NVARCHAR (50)    NULL,
    [address]      NVARCHAR (50)    NULL,
    [city]         NVARCHAR (50)    NULL,
    [state]        NVARCHAR (50)    NULL,
    [zip]          INT              NULL,
    [website]      NVARCHAR (50)    NULL,
    [phone]        NVARCHAR (50)    NULL,
    [siteId]       INT              NULL,
    [created]      DATETIME         DEFAULT (getdate()) NULL,
    [modified]     DATETIME         DEFAULT (getdate()) NULL,
    [createdBy]    INT              NULL,
    [modifiedBy]   INT              NULL,
    [isActive]     BIT              NULL,
    PRIMARY KEY CLUSTERED ([jobCompanyId] ASC)
);

