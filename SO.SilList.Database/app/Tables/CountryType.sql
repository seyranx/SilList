CREATE TABLE [app].[CountryType]
(
	[countryTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NULL,
		[created]       DATETIME       CONSTRAINT [DF__CarCountryTy__creat__0E391C95] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__CarCountryTy__modif__0F2D40CE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            CONSTRAINT [DF__CarCountryTy__isAct__10216507] DEFAULT ((1)) NOT NULL
)
