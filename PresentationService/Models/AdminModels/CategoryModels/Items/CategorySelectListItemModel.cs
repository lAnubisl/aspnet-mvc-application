namespace PresentationService.Models.AdminModels.CategoryModels.Items
{
    public class CategorySelectListItemModel
    {
        public CategorySelectListItemModel(string categoryName, long categoryId)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public long CategoryId { get; private set; }

        public string CategoryName { get; private set; }
    }
}