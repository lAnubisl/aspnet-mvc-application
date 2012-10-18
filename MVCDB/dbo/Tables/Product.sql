CREATE TABLE [dbo].[Product] (
    [ProductId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]      BIGINT         NOT NULL,
    [CategoryId]  BIGINT         NOT NULL,
    [Price]       FLOAT (53)     NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]),
    CONSTRAINT [FK_Product_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

