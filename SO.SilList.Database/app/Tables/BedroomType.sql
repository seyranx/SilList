CREATE TABLE [app].[BedroomType] (
    [bedroomTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [name]          VARCHAR (15) NOT NULL,
    [created]       DATETIME     CONSTRAINT [DF__tmp_ms_xx__creat__7FB5F314] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME     CONSTRAINT [DF__tmp_ms_xx__modif__00AA174D] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT          NULL,
    [modifiedBy]    INT          NULL,
    [isActive]      BIT          CONSTRAINT [DF__tmp_ms_xx__isAct__019E3B86] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__6B630DA0084FA8C4] PRIMARY KEY CLUSTERED ([bedroomTypeId] ASC)
);



