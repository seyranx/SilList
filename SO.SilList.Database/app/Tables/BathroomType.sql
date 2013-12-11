CREATE TABLE [app].[BathroomType] (
    [bathroomTypeId] INT          NOT NULL,
    [name]           VARCHAR (15) NOT NULL,
    [created]        DATETIME     DEFAULT (getdate()) NOT NULL,
    [modified]       DATETIME     DEFAULT (getdate()) NOT NULL,
    [createdBy]      INT          NULL,
    [modifiedBy]     INT          NULL,
    [isActive]       BIT          DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([bathroomTypeId] ASC)
);

