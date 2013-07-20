CREATE TABLE [data].[LeaseTermType] (
    [leaseTermTypeId] INT            NOT NULL,
    [name]            NVARCHAR (50)  NULL,
    [description]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([leaseTermTypeId] ASC)
);



