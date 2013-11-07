CREATE TABLE [app].[StatusType] (
    [statusTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (50)  NULL,
    [description]  NVARCHAR (MAX) NULL,
    [modifiedBy]   INT            NULL,
    [modified]     DATETIME       CONSTRAINT [DF_StatusType_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]    INT            NULL,
    [created]      DATETIME       CONSTRAINT [DF_StatusType_created] DEFAULT (getdate()) NOT NULL,
    [isActive]     BIT            CONSTRAINT [DF_StatusType_isActive2] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_StatusType_1] PRIMARY KEY CLUSTERED ([statusTypeId] ASC)
);

