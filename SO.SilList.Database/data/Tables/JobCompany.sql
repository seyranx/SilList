CREATE TABLE [data].[JobCompany] (
    [jobCompanyId]  UNIQUEIDENTIFIER NOT NULL,
    [name]          NVARCHAR (50)    NULL,
    [address]       NVARCHAR (MAX)   NULL,
    [cityTypeId]    INT              NULL,
    [stateTypeId]   INT              NULL,
    [countryTypeId] INT              NULL,
    [zip]           INT              NULL,
    [phone]         NVARCHAR (50)    NULL,
    [fax]           NVARCHAR (50)    NULL,
    [website]       NVARCHAR (50)    NULL,
    [siteId]        INT              NULL,
    [created]       DATETIME         CONSTRAINT [DF__JobCompan__creat__236943A5] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME         CONSTRAINT [DF__JobCompan__modif__245D67DE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT              NULL,
    [modifiedBy]    INT              NULL,
    [isActive]      BIT              DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__JobCompa__A2D2B0051CF0B5EC] PRIMARY KEY CLUSTERED ([jobCompanyId] ASC),
    CONSTRAINT [FK_JobCompany_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]),
    CONSTRAINT [FK_JobCompany_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]),
    CONSTRAINT [FK_JobCompany_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId])
);

