CREATE TABLE [app].[BathroomType] (
    [bathroomTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [name]           VARCHAR (15) NOT NULL,
    [created]        DATETIME     CONSTRAINT [DF__tmp_ms_xx__creat__7AF13DF7] DEFAULT (getdate()) NOT NULL,
    [modified]       DATETIME     CONSTRAINT [DF__tmp_ms_xx__modif__7BE56230] DEFAULT (getdate()) NOT NULL,
    [createdBy]      INT          NULL,
    [modifiedBy]     INT          NULL,
    [isActive]       BIT          CONSTRAINT [DF__tmp_ms_xx__isAct__7CD98669] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__02DDF956D969E3AE] PRIMARY KEY CLUSTERED ([bathroomTypeId] ASC)
);


