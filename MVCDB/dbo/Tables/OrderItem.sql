CREATE TABLE [dbo].[OrderItem] (
    [OrderItemId] BIGINT IDENTITY (1, 1) NOT NULL,
    [OrderId]     BIGINT NOT NULL,
    [ProductId]   BIGINT NOT NULL,
    [Price]       BIGINT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([OrderItemId] ASC),
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]),
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

