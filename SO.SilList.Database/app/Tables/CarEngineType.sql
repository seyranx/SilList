CREATE TABLE [app].[CarEngineType]
(
	[carEngineId] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NOT NULL,
	[created]       DATETIME       CONSTRAINT [DF__CarEngineTy__creat__0E391C95] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__CarEngineTy__modif__0F2D40CE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            CONSTRAINT [DF__CarEngineTy__isAct__10216507] DEFAULT ((1)) NOT NULL
)
