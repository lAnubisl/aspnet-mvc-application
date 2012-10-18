CREATE TABLE [dbo].[Log] (
    [LogId]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME       NOT NULL,
    [Thread]    NVARCHAR (MAX) NOT NULL,
    [Level]     NVARCHAR (MAX) NOT NULL,
    [Logger]    NVARCHAR (MAX) NOT NULL,
    [Message]   NVARCHAR (MAX) NOT NULL,
    [Exception] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId] ASC)
);

