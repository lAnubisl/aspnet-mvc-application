CREATE TABLE [dbo].[Order] (
    [OrderId]       BIGINT   IDENTITY (1, 1) NOT NULL,
    [UserId]        BIGINT   NOT NULL,
    [Date]          DATETIME NULL,
    [OrderStatusId] BIGINT   NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([OrderStatusId]),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_Order_User1] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

