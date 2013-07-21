CREATE TABLE [data].[LeaseTermType] (
    [leaseTermTypeId] INT            NOT NULL,
    [name]            NVARCHAR (50)  NULL,
    [description]     NVARCHAR (MAX) NULL,
    [modifiedBy]      INT            NULL,
    [modified]        DATETIME       CONSTRAINT [DF_LeaseTermType_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT            NULL,
    [created]         DATETIME       CONSTRAINT [DF_LeaseTermType_created] DEFAULT (getdate()) NOT NULL,
    [isActive]        BIT            CONSTRAINT [DF_LeaseTermType_isActive] DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([leaseTermTypeId] ASC)
);

