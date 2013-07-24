namespace PresentationService.Models.AdminModels.ProductModels.Items
{
    public class ProductIndexItemModel
    {
        private readonly string productName;
        private readonly long productId;

        internal ProductIndexItemModel(string productName, long productId)
        {
            this.productId = productId;
            this.productName = productName;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
        }

        public long ProductId
        {
            get
            {
                return this.productId;
            }
        }
    }
}