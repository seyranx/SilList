CREATE TABLE [data].[BusinessServices] (
    [businessServiceId] UNIQUEIDENTIFIER NOT NULL,
    [serviceTypeId]     INT              NULL,
    [businessId]        UNIQUEIDENTIFIER NULL,
    [created]           DATETIME         CONSTRAINT [DF__BusinessS__creat__59FA5E80] DEFAULT (getdate()) NULL,
    [modified]          DATETIME         CONSTRAINT [DF__BusinessS__modif__5AEE82B9] DEFAULT (getdate()) NULL,
    [createdBy]         INT              NULL,
    [modifiedBy]        INT              NULL,
    [isActive]          BIT              NOT NULL DEFAULT ((1)),
    CONSTRAINT [PK_BusinessServices] PRIMARY KEY CLUSTERED ([businessServiceId] ASC),
    CONSTRAINT [FK_BusinessServices_Business] FOREIGN KEY ([businessId]) REFERENCES [data].[Business] ([businessId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BusinessServices_ServiceType] FOREIGN KEY ([serviceTypeId]) REFERENCES [app].[ServiceType] ([serviceTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);






