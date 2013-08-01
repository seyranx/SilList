CREATE TABLE [data].[BusinessImages] (
    [businessImageId] UNIQUEIDENTIFIER CONSTRAINT [DF_BusinessImages_businessImageId] DEFAULT (newid()) NOT NULL,
    [imageId]         UNIQUEIDENTIFIER NULL,
    [businessId]      UNIQUEIDENTIFIER NULL,
    [created]         DATETIME         CONSTRAINT [DF__BusinessI__creat__5812160E] DEFAULT (getdate()) NOT NULL,
    [modified]        DATETIME         CONSTRAINT [DF__BusinessI__modif__59063A47] DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT              NULL,
    [modifiedBy]      INT              NULL,
    [isActive]        BIT              CONSTRAINT [DF_BusinessImages_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BusinessImages_1] PRIMARY KEY CLUSTERED ([businessImageId] ASC),
    CONSTRAINT [FK_BusinessImages_Business] FOREIGN KEY ([businessId]) REFERENCES [data].[Business] ([businessId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BusinessImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE
);









