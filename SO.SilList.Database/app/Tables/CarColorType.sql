CREATE TABLE [app].[CarColorType] (
    [carColorTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (50)  NOT NULL,
    [created]       DATETIME       CONSTRAINT [DF__CarColorTy__creat__0E391C95] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__CarColorTy__modif__0F2D40CE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            CONSTRAINT [DF__CarColorTy__isAct__10216507] DEFAULT ((1)) NOT NULL, 
    CONSTRAINT [PK_CarColorType] PRIMARY KEY ([carColorTypeId]),
);


