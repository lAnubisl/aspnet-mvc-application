namespace PresentationService.Models.AdminModels.ProductModels
{
    public class ProductUploadImageModel
    {
        public string ImageUrl { get; set; }

        public bool Success { get; private set; }
    }
}