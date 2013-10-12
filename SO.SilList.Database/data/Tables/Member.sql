CREATE TABLE [data].[Member] (
    [memberId]          INT            IDENTITY (1, 1) NOT NULL,
    [siteId]            INT            NULL,
    [firstName]         NVARCHAR (50)  NULL,
    [lastName]          NVARCHAR (50)  NULL,
    [address]           NVARCHAR (MAX) NULL,
    [cityTypeId]            INT            NULL,
    [stateTypeId]           INT            NULL,
    [CountryTypeId]         INT            NULL,
    [zip]               INT            NULL,
    [fax]               NVARCHAR (50)  NULL,
    [email]             NVARCHAR (50)  NULL,
    [username]          NVARCHAR (50)  NULL,
    [password]          NVARCHAR (50)  NULL,
    [phone]             NVARCHAR (50)  NULL,
    [isEmailConfirmed]  BIT            CONSTRAINT [DF__Member__isEmailC__619B8048] DEFAULT ((0)) NULL,
    [ipAddress]         NVARCHAR (50)  NULL,
    [lastLogin]         DATETIME       CONSTRAINT [DF__Member__lastLogi__628FA481] DEFAULT (getdate()) NOT NULL,
    [isEmailSubscribed] BIT            CONSTRAINT [DF__Member__isEmailS__6383C8BA] DEFAULT ((0)) NULL,
    [created]           DATETIME       CONSTRAINT [DF__Member__created__6477ECF3] DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME       CONSTRAINT [DF__Member__modified__656C112C] DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT            NULL,
    [modifiedBy]        INT            NULL,
    [isActive]          BIT            CONSTRAINT [DF__Member__isActive__66603565] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([memberId] ASC),
    CONSTRAINT [FK_Member_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]),
    CONSTRAINT [FK_Member_CountryType] FOREIGN KEY ([CountryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]),
    CONSTRAINT [FK_Member_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]),
    CONSTRAINT [FK_Member_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId])
);










