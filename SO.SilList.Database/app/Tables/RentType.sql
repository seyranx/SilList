CREATE TABLE [app].[RentType] (
    [rentTypeId]  INT            NOT NULL,
    [name]        NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (MAX) NOT NULL,
    [created]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [modified]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [createdBy]   INT            NULL,
    [modifiedBy]  INT            NULL,
    [isActive]    BIT            DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([rentTypeId] ASC)
);




