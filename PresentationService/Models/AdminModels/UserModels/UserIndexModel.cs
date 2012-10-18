namespace PresentationService.Models.AdminModels.UserModels
{
    using System.Collections.Generic;

    using PresentationService.Models.AdminModels.UserModels.Items;

    public class UserIndexModel
    {
        public UserIndexModel(IEnumerable<UserIndexItemModel> users)
        {
            Users = users;
        }

        public IEnumerable<UserIndexItemModel> Users { get; private set; } 
    }
}
