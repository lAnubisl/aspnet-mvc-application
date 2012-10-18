CREATE VIEW dbo.AvailableProduct
AS
SELECT        ProductId, Count
FROM          (SELECT        P.ProductId, SUM(IP.Count) AS Count
                          FROM            dbo.Product AS P INNER JOIN
                                                    dbo.IncomingProduct AS IP ON P.ProductId = IP.ProductId INNER JOIN
                                                    dbo.Consignment AS C ON IP.ConsignmentId = C.ConsignmentId
                          WHERE        (C.ConsignmentStatusId = 2)
                          GROUP BY P.ProductId) AS AP
WHERE        (Count > 0)
-- This view has been changed by Alex
GO