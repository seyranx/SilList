CREATE TABLE [app].[PropertyListingType] (
    [propertyListingTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]                  NVARCHAR (50)  NULL,
    [description]           NVARCHAR (MAX) NULL,
    [modifiedBy]            INT            NULL,
    [modified]              DATETIME       CONSTRAINT [DF_PropertyListingType_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]             INT            NULL,
    [created]               DATETIME       CONSTRAINT [DF_PropertyListingType_created] DEFAULT (getdate()) NOT NULL,
    [isActive]              BIT            CONSTRAINT [DF_PropertyListingType_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__PropertyListingType__AB7EA317CEFCE3EB] PRIMARY KEY CLUSTERED ([propertyListingTypeId] ASC)
);

