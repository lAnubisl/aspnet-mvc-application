using System.Collections.Generic;
using System.ComponentModel;
using PresentationService.Helpers;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.ProductModels
{
    public class EditProductModel
    {
        private IEnumerable<SelectListItemPresenter> categories;

        [CommonRequired]
        public long UserId { get; set; }

        public long ProductId { get; set; }

        [DisplayName("Category"), CommonRequired]
        public long CategoryId { get; set; }

        [DisplayName("Price"), CommonRequired]
        public float Price { get; set; }

        [DisplayName("Name"), CommonRequired, CommonStringLength(50)]
        public string Name { get; set; }

        [DisplayName("Description"), CommonRequired, CommonStringLength(256)]
        public string Description { get; set; }

        public IEnumerable<SelectListItemPresenter> Categories
        {
            get
            {
                return categories ?? (categories = new List<SelectListItemPresenter>());
            }

            set
            {
                categories = value;
            }
        }
    }
}