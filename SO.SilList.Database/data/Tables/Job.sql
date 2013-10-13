CREATE TABLE [data].[Job] (
    [jobId]            UNIQUEIDENTIFIER NOT NULL,
    [siteId]           INT              NULL,
    [title]            NVARCHAR (50)    NULL,
    [description]      NVARCHAR (50)    NULL,
    [jobTypeId]        INT              NULL,
    [address]          NVARCHAR (MAX)   NULL,
    [cityTypeId]           INT              NULL,
    [stateTypeId]          INT              NULL,
    [countryTypeId]        INT              NULL,
    [zip]              INT              NULL,
    [phone]            NVARCHAR (50)    NULL,
    [fax]              NVARCHAR (50)    NULL,
    [isTravelRequired] BIT              NULL,
    [isTelecomute]     BIT              NULL,
    [jobCompanyId]     UNIQUEIDENTIFIER NULL,
    [startDate]        DATE             NOT NULL,
    [endDate]          DATE             NOT NULL,
    [isApproved]       BIT              DEFAULT ((0)) NOT NULL,
    [created]          DATE             NOT NULL DEFAULT (getdate()),
    [modified]         DATETIME         NOT NULL DEFAULT (getdate()),
    [createdBy]        INT              NULL,
    [modifiedBy]       INT              NULL,
    [isActive]         BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([jobId] ASC),
    CONSTRAINT [FK_Job_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_JobCompany1] FOREIGN KEY ([jobCompanyId]) REFERENCES [data].[JobCompany] ([jobCompanyId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_JobType1] FOREIGN KEY ([jobTypeId]) REFERENCES [app].[JobType] ([jobTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);













