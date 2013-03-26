using System;
using System.ComponentModel.DataAnnotations;
using DomainService.DomainModels;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ConsignmentModels.Items
{
    public class ConsignmentEditItemModel
    {
        public ConsignmentEditItemModel()
        {
        }

        internal ConsignmentEditItemModel(IncomingProduct incomingProduct)
        {
            if (incomingProduct == null)
            {
                throw new ArgumentNullException("incomingProduct");
            }

            Count = incomingProduct.Count;
            Name = incomingProduct.Product.Name;
        }

        [Display(Name = "ProductCount", ResourceType = typeof(Resources.EntityNames)), PositiveNumber]
        public long Count { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(Resources.EntityNames)), CommonRequired, RealProductName]
        public string Name { get; set; }
    }
}