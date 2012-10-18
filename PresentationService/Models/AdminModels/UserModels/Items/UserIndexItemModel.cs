namespace PresentationService.Models.AdminModels.UserModels.Items
{
    public class UserIndexItemModel
    {
        public UserIndexItemModel(string fullName, long userId)
        {
            UserId = userId;
            FullName = fullName;
        }

        public string FullName { get; private set; }

        public long UserId { get; private set; }
    }
}
