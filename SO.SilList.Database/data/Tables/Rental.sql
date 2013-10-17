CREATE TABLE [data].[Rental] (
	[rentalId]        UNIQUEIDENTIFIER NOT NULL,
	[title]			  NVARCHAR(50) NULL,
	[address]		  NVARCHAR(50) NULL,
	[phone]			  NVARCHAR(15) NULL, 
    [description]	  NVARCHAR(MAX) NULL,
    [propertyTypeId]  INT              NULL,
    [siteId]          INT              NULL,
    [bedrooms]        INT              NULL,
    [bathrooms]       INT              NULL,
    [rent]            FLOAT (53)       NULL,
    [leaseTermTypeId] INT              NULL,
    [size]            INT              NULL,
    [lotSize]         INT              NULL,
    [acceptsSection8] BIT              NULL,
    [rentTypeId]      INT              NULL,
	[memberId]		  INT			   NULL, 
    [startDate]		  DATE             NOT NULL,
    [endDate]         DATE             NOT NULL,
    [isApproved]      BIT              NOT NULL DEFAULT (0),
    [modifiedBy]      INT              NULL,
    [modified]        DATETIME         CONSTRAINT [DF_Rental_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT              NULL,
    [created]         DATETIME         CONSTRAINT [DF_Rental_created] DEFAULT (getdate()) NOT NULL,
    [isActive]        BIT              CONSTRAINT [DF_Rental_isActive] DEFAULT ((1)) NOT NULL, 
    PRIMARY KEY CLUSTERED ([rentalId] ASC),
    CONSTRAINT [FK_Rental_LeaseTermType] FOREIGN KEY ([leaseTermTypeId]) REFERENCES [app].[LeaseTermType] ([leaseTermTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_Member] FOREIGN KEY (memberId) REFERENCES [data].[Member] ([memberId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_PropertyType] FOREIGN KEY ([propertyTypeId]) REFERENCES [app].[PropertyType] ([propertyTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_RentType] FOREIGN KEY ([rentTypeId]) REFERENCES [app].[RentType] ([rentTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
);













