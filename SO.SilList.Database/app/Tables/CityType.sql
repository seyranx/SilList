CREATE TABLE [app].[CityType] (
    [cityTypeId]    INT           IDENTITY (1, 1) NOT NULL,
    [stateTypeId]   INT           NOT NULL,
    [countryTypeId] INT           NOT NULL,
    [name]          NVARCHAR (50) NULL,
    [created]       DATETIME      CONSTRAINT [DF__CarCityTy__creat__0E391C95] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME      CONSTRAINT [DF__CarCityTy__modif__0F2D40CE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT           NULL,
    [modifiedBy]    INT           NULL,
    [isActive]      BIT           CONSTRAINT [DF__CarCityTy__isAct__10216507] DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([cityTypeId] ASC),
    CONSTRAINT [FK_CityType_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]),
    CONSTRAINT [FK_CityType_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId])
);


