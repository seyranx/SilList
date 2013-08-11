CREATE TABLE [data].[Car] (
    [carId]              UNIQUEIDENTIFIER NOT NULL,
    [modelTypeId]        INT              NULL,
    [year]               INT              NULL,
    [millage]            INT              NULL,
    [carBodyTypeId]      INT              NULL,
    [siteId]             INT              NULL,
    [transmissionTypeId] INT              NULL,
	[startDate] DATE NOT NULL DEFAULT getdate(), 
    [endDate] DATE NOT NULL DEFAULT getdate(), 
    [isApproved] BIT NOT NULL DEFAULT ((0)),
    [created]            DATETIME         CONSTRAINT [DF__Car__created__19AACF41] DEFAULT (getdate()) NOT NULL,
    [modified]           DATETIME         CONSTRAINT [DF__Car__modified__1A9EF37A] DEFAULT (getdate()) NOT NULL,
    [createdBy]          INT              NULL,
    [modifiedBy]         INT              NULL,
    [isActive]           BIT              CONSTRAINT [DF__Car__isActive__1B9317B3] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Car__1436F1744758F06A] PRIMARY KEY CLUSTERED ([carId] ASC),
    CONSTRAINT [FK_Car_CarBodyType] FOREIGN KEY ([carBodyTypeId]) REFERENCES [app].[CarBodyType] ([carBodyTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_ModelType] FOREIGN KEY ([modelTypeId]) REFERENCES [app].[ModelType] ([modelTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_TransmissionType] FOREIGN KEY ([transmissionTypeId]) REFERENCES [app].[TransmissionType] ([transmissionTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);




