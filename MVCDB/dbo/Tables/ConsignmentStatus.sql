CREATE TABLE [dbo].[ConsignmentStatus] (
    [ConsignmentStatusId] BIGINT NOT NULL,
    [Name]                NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_ConsignmentStatus] PRIMARY KEY CLUSTERED ([ConsignmentStatusId] ASC)
);

