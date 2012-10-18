CREATE TABLE [dbo].[IncomingProduct] (
    [IncomingProductId] BIGINT IDENTITY (1, 1) NOT NULL,
    [Count]             BIGINT NOT NULL,
    [ProductId]         BIGINT NOT NULL,
    [ConsignmentId]     BIGINT NOT NULL,
    CONSTRAINT [PK_IncomingProduct] PRIMARY KEY CLUSTERED ([IncomingProductId] ASC),
    CONSTRAINT [FK_IncomingProduct_Consignment] FOREIGN KEY ([ConsignmentId]) REFERENCES [dbo].[Consignment] ([ConsignmentId]),
    CONSTRAINT [FK_IncomingProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

