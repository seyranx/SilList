CREATE TABLE [app].[RentType] (
    [rentTypeId]  INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (MAX) NOT NULL,
    [created]     DATETIME       CONSTRAINT [DF__RentType__create__37A5467C] DEFAULT (getdate()) NOT NULL,
    [modified]    DATETIME       CONSTRAINT [DF__RentType__modifi__38996AB5] DEFAULT (getdate()) NOT NULL,
    [createdBy]   INT            NULL,
    [modifiedBy]  INT            NULL,
    [isActive]    BIT            CONSTRAINT [DF__RentType__isActi__30C33EC3] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__RentType__82E01919321D0208] PRIMARY KEY CLUSTERED ([rentTypeId] ASC)
);






