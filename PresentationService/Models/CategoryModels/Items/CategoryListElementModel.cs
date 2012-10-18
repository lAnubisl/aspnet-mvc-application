namespace PresentationService.Models.CategoryModels.Items
{
    public class CategoryListElementModel
    {
        public CategoryListElementModel(string categoryName, long categoryId)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public long CategoryId { get; private set; }

        public string CategoryName { get; private set; }
    }
}