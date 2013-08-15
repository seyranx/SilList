CREATE TABLE [data].[CarImages] (
	[carImagesId]    UNIQUEIDENTIFIER NOT NULL,
    [imageId]    UNIQUEIDENTIFIER NULL,
    [carId]      UNIQUEIDENTIFIER NULL,
    [created]    DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([carImagesId]),
    CONSTRAINT [FK_CarImages_Car] FOREIGN KEY ([carId]) REFERENCES [data].[Car] ([carId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_CarImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE
);


