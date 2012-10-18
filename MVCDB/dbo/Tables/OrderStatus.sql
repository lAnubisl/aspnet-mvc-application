CREATE TABLE [dbo].[OrderStatus] (
    [OrderStatusId] BIGINT         NOT NULL,
    [Name]          NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED ([OrderStatusId] ASC)
);

