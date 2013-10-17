CREATE TABLE [app].[CarDriveType]
(
	[carDriveTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NCHAR(10) NOT NULL,
	[created]       DATETIME       CONSTRAINT [DF__CarDriveTy__creat__0E391C95] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__CarDriveTy__modif__0F2D40CE] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            CONSTRAINT [DF__CarDriveTy__isAct__10216507] DEFAULT ((1)) NOT NULL
)
