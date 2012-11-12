CREATE VIEW dbo.AvailableProduct
AS
SELECT 
	T.ProductId,
	T.[Count],
	T.IsUnlimitedProduct
FROM (
	SELECT        
		P.ProductId, 
		SUM(IP.[Count]) AS [Count],
		p.IsUnlimitedProduct
    FROM            
		dbo.Product AS P 
	LEFT JOIN dbo.IncomingProduct AS IP 
		ON P.ProductId = IP.ProductId 
	LEFT JOIN dbo.Consignment AS C 
		ON IP.ConsignmentId = C.ConsignmentId
    WHERE 
		P.IsUnlimitedProduct = 1 OR C.ConsignmentStatusId = 2 
	GROUP BY P.ProductId, p.IsUnlimitedProduct
	) AS T
WHERE T.[Count] > 0 OR T.IsUnlimitedProduct = 1
GO