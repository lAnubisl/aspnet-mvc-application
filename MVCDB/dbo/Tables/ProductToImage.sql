﻿CREATE TABLE [dbo].[ProductToImage]
(
	[ProductId] BIGINT NOT NULL , 
    [ImageId] BIGINT NOT NULL, 
    CONSTRAINT [PK_ProductToImage] PRIMARY KEY CLUSTERED ([ProductId], [ImageId]), 
    CONSTRAINT [FK_ProductToImage_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]),
	CONSTRAINT [FK_ProductToImage_Image] FOREIGN KEY ([ImageId]) REFERENCES [Image]([ImageId])
)

GO