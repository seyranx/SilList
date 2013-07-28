﻿CREATE TABLE [data].[BusinessImages] (
    [businessImagesId] UNIQUEIDENTIFIER NOT NULL,
    [imageId]          UNIQUEIDENTIFIER NULL,
    [businessId]       UNIQUEIDENTIFIER NULL,
    [created]          DATETIME         CONSTRAINT [DF__BusinessI__creat__5812160E] DEFAULT (getdate()) NULL,
    [modified]         DATETIME         CONSTRAINT [DF__BusinessI__modif__59063A47] DEFAULT (getdate()) NULL,
    [craetedBy]        INT              NULL,
    [modifiedBy]       INT              NULL,
    [isActive]         BIT              NULL,
    CONSTRAINT [PK_BusinessImages] PRIMARY KEY CLUSTERED ([businessImagesId] ASC),
    CONSTRAINT [FK_BusinessImages_Business] FOREIGN KEY ([businessId]) REFERENCES [data].[Business] ([businessId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BusinessImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE
);







