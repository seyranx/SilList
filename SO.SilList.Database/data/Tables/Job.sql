CREATE TABLE [data].[Job] (
    [jobId]             UNIQUEIDENTIFIER NOT NULL,
    [siteId]            INT              NULL,
    [title]             NVARCHAR (50)    NULL,
    [description]       NVARCHAR (MAX)   NULL,
    [jobTypeId]         INT              NULL,
    [address]           NVARCHAR (MAX)   NULL,
    [cityTypeId]        INT              NULL,
    [stateTypeId]       INT              NULL,
    [countryTypeId]     INT              NULL,
    [zip]               INT              NULL,
    [phone]             NVARCHAR (50)    NULL,
    [fax]               NVARCHAR (50)    NULL,
    [website]           NVARCHAR (50)    NULL,
    [contactName]       NVARCHAR (50)    NULL,
    [companyName]       NVARCHAR (50)    NULL,
    [email]             NVARCHAR (50)    NULL,
    [entryStatusTypeId] INT              CONSTRAINT [DF__tmp_ms_xx__isApp__3B0BC30C] DEFAULT ((1)) NULL,
    [startDate]         DATE             NOT NULL,
    [endDate]           DATE             NOT NULL,
    [created]           DATE             CONSTRAINT [DF__tmp_ms_xx__creat__3BFFE745] DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME         CONSTRAINT [DF__tmp_ms_xx__modif__3CF40B7E] DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT              NULL,
    [modifiedBy]        INT              NULL,
    [isActive]          BIT              CONSTRAINT [DF__tmp_ms_xx__isAct__3DE82FB7] DEFAULT ((1)) NOT NULL,
    [isTravelRequired]  BIT              DEFAULT ((0)) NOT NULL,
    [isTelecomute]      BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__164AA1A8BD5F9C61] PRIMARY KEY CLUSTERED ([jobId] ASC),
    CONSTRAINT [FK_Job_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_EntryStatusType] FOREIGN KEY ([entryStatusTypeId]) REFERENCES [app].[EntryStatusType] ([entryStatusTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_JobType1] FOREIGN KEY ([jobTypeId]) REFERENCES [app].[JobType] ([jobTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Job_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);

























