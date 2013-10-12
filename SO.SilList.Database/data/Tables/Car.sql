CREATE TABLE [data].[Car] (
    [carId]               UNIQUEIDENTIFIER NOT NULL,
    [modelTypeId]         INT              NULL,
    [year]                INT              NULL,
    [millage]             INT              NULL,
    [price]               INT              NULL,
    [vin]                 NVARCHAR (50)    NULL,
    [description]         NVARCHAR (MAX)   NULL,
    [address]             NVARCHAR (MAX)   NULL,
    [cityTypeId]              INT              NULL,
    [stateTypeId]             INT              NULL,
    [countryTypeId]           INT              NULL,
    [zip]                 INT              NULL,
    [phone]               NVARCHAR (50)    NULL,
    [fax]                 NVARCHAR (50)    NULL,
    [carBodyTypeId]       INT              NULL,
    [siteId]              INT              NULL,
    [transmissionTypeId]  INT              NULL,
    [carEngineTypeId]        INT              NULL,
    [carDriveTypeId]         INT              NULL,
    [carFuelTypeId]          INT              NULL,
    [carDoorTypeId]          INT              NULL,
    [exteriorColorTypeId] INT              NULL,
    [interiorColorTypeId] INT              NULL,
    [startDate]           DATE             NOT NULL,
    [endDate]             DATE             NOT NULL,
    [isApproved]          BIT              DEFAULT ((0)) NOT NULL,
    [created]             DATETIME         CONSTRAINT [DF__Car__created__19AACF41] DEFAULT (getdate()) NOT NULL,
    [modified]            DATETIME         CONSTRAINT [DF__Car__modified__1A9EF37A] DEFAULT (getdate()) NOT NULL,
    [createdBy]           INT              NULL,
    [modifiedBy]          INT              NULL,
    [isActive]            BIT              CONSTRAINT [DF__Car__isActive__1B9317B3] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Car__1436F1744758F06A] PRIMARY KEY CLUSTERED ([carId] ASC),
    CONSTRAINT [FK_Car_CarBodyType] FOREIGN KEY ([carBodyTypeId]) REFERENCES [app].[CarBodyType] ([carBodyTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CarDoorType] FOREIGN KEY ([carDoorTypeId]) REFERENCES [app].[CarDoorType] ([carDoorTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CarDriveType] FOREIGN KEY ([carDriveTypeId]) REFERENCES [app].[CarDriveType] ([carDriveTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CarEngineType] FOREIGN KEY ([carEngineTypeId]) REFERENCES [app].[CarEngineType] ([carEngineTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CarFuelType] FOREIGN KEY ([carFuelTypeId]) REFERENCES [app].[CarFuelType] ([carFuelTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_ModelType] FOREIGN KEY ([modelTypeId]) REFERENCES [app].[ModelType] ([modelTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_TransmissionType] FOREIGN KEY ([transmissionTypeId]) REFERENCES [app].[TransmissionType] ([transmissionTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_CarExt_CarColorType] FOREIGN KEY ([exteriorColorTypeId]) REFERENCES [app].[CarColorType] ([carColorTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_CarInt_CarColorType] FOREIGN KEY ([interiorColorTypeId]) REFERENCES [app].[CarColorType] ([carColorTypeId])
);








