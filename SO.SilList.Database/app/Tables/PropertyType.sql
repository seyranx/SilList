CREATE TABLE [app].[PropertyType] (
    [propertyTypeId] INT           NOT NULL,
    [name]           NVARCHAR (50) NOT NULL,
    [description]    NVARCHAR (50) NOT NULL,
    [created]        DATETIME      DEFAULT (getdate()) NOT NULL,
    [modified]       DATETIME      DEFAULT (getdate()) NOT NULL,
    [createdBy]      INT           NULL,
    [modifiedBy]     INT           NULL,
    [isActive]       BIT           NULL,
    PRIMARY KEY CLUSTERED ([propertyTypeId] ASC)
);




