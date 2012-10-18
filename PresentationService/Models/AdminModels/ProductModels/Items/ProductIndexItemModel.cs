namespace PresentationService.Models.AdminModels.ProductModels.Items
{
    public class ProductIndexItemModel
    {
        public ProductIndexItemModel(string productName, long productId)
        {
            ProductId = productId;
            ProductName = productName;
        }

        public string ProductName { get; private set; }

        public long ProductId { get; private set; }
    }
}