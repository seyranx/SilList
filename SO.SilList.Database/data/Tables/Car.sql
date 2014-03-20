CREATE TABLE [data].[Car] (
    [carId]                     UNIQUEIDENTIFIER NOT NULL,
    [carModelTypeId]            INT              NULL,
    [year]                      INT              NULL,
    [millage]                   INT              NULL,
    [price]                     INT              NULL,
    [vin]                       NVARCHAR (50)    NULL,
    [description]               NVARCHAR (MAX)   NULL,
    [address]                   NVARCHAR (MAX)   NULL,
    [cityTypeId]                INT              NULL,
    [stateTypeId]               INT              NULL,
    [countryTypeId]             INT              NULL,
    [zip]                       INT              NULL,
    [bodyOptionTypeId]          INT              NULL,
    [transmissionOptionTypeId]  INT              NULL,
    [engineOptionTypeId]        INT              NULL,
    [driveOptionTypeId]         INT              NULL,
    [fuelOptionTypeId]          INT              NULL,
    [doorOptionTypeId]          INT              NULL,
    [exteriorColorOptionTypeId] INT              NULL,
    [interiorColorOptionTypeId] INT              NULL,
    [startDate]                 DATE             NOT NULL,
    [endDate]                   DATE             NOT NULL,
    [listingStatusTypeId]       INT              DEFAULT ((1)) NULL,
    [created]                   DATETIME         CONSTRAINT [DF__Car__created__19AACF41] DEFAULT (getdate()) NOT NULL,
    [modified]                  DATETIME         CONSTRAINT [DF__Car__modified__1A9EF37A] DEFAULT (getdate()) NOT NULL,
    [createdBy]                 INT              NULL,
    [modifiedBy]                INT              NULL,
    [isActive]                  BIT              CONSTRAINT [DF__Car__isActive__1B9317B3] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Car__1436F1744758F06A] PRIMARY KEY CLUSTERED ([carId] ASC),
    CONSTRAINT [FK_Car_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_EntryStatusType] FOREIGN KEY ([listingStatusTypeId]) REFERENCES [app].[ListingStatusType] ([listingStatusTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_ModelType] FOREIGN KEY ([carModelTypeId]) REFERENCES [app].[CarModelType] ([carModelTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);










