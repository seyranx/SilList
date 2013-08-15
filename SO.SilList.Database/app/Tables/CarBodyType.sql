CREATE TABLE [app].[CarBodyType] (
    [carBodyTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (50)  NULL,
    [description]   NVARCHAR (MAX) NULL,
    [created]       DATETIME       CONSTRAINT [DF__CarBodyTy__creat__0E391C95] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__CarBodyTy__modif__0F2D40CE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            CONSTRAINT [DF__CarBodyTy__isAct__10216507] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__CarBodyT__3CA95E9B6DF47A74] PRIMARY KEY CLUSTERED ([carBodyTypeId] ASC)
);


