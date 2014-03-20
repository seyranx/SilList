CREATE TABLE [app].[CarMakeType] (
    [carMakeTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (50)  NULL,
    [description]   NVARCHAR (MAX) NULL,
    [created]       DATETIME       CONSTRAINT [DF__MakeType__create__11158940] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__MakeType__modifi__1209AD79] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            CONSTRAINT [DF__MakeType__isActi__12FDD1B2] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__MakeType__FCBD44ABF84B64C8] PRIMARY KEY CLUSTERED ([carMakeTypeId] ASC)
);

