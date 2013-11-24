CREATE TABLE [data].[PropertyImages] (
    [propertyImageId] UNIQUEIDENTIFIER NOT NULL,
    [imageId]         UNIQUEIDENTIFIER NULL,
    [propertyId]      UNIQUEIDENTIFIER NULL,
    [created]         DATETIME         CONSTRAINT [DF__PropertyIma__creat__6FE99F9F] DEFAULT (getdate()) NOT NULL,
    [modified]        DATETIME         CONSTRAINT [DF__PropertyIma__modif__70DDC3D8] DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT              NULL,
    [modifiedBy]      INT              NULL,
    [isActive]        BIT              CONSTRAINT [DF_PropertyImages_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__PropertyIm__336E9B55254858FA] PRIMARY KEY CLUSTERED ([propertyImageId] ASC),
    CONSTRAINT [FK_PropertyImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PropertyImages_Property] FOREIGN KEY ([propertyId]) REFERENCES [data].[Property] ([propertyId]) ON DELETE CASCADE ON UPDATE CASCADE
);

