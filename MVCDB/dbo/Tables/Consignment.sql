CREATE TABLE [dbo].[Consignment] (
    [ConsignmentId]       BIGINT   IDENTITY (1, 1) NOT NULL,
    [UserId]              BIGINT   NOT NULL,
    [ConsignmentStatusId] BIGINT   NOT NULL,
    [CreationDate]        DATETIME NOT NULL,
    CONSTRAINT [PK_Consignment] PRIMARY KEY CLUSTERED ([ConsignmentId] ASC),
    CONSTRAINT [FK_Consignment_ConsignmentStatus] FOREIGN KEY ([ConsignmentStatusId]) REFERENCES [dbo].[ConsignmentStatus] ([ConsignmentStatusId]),
    CONSTRAINT [FK_Consignment_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

