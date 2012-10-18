using System;
using DomainService.DomainModels;
using PresentationService.ValidationAttributes;

namespace PresentationService.Models.AdminModels.ConsignmentModels.Items
{
    public class ConsignmentEditItemModel
    {
        public ConsignmentEditItemModel()
        {
        }

        public ConsignmentEditItemModel(IncomingProduct incomingProduct)
        {
            if (incomingProduct == null)
            {
                throw new ArgumentNullException("incomingProduct");
            }

            Count = incomingProduct.Count;
            Name = incomingProduct.Product.Name;
        }

        [ProductCountCorrect]
        public long Count { get; set; }

        [ProductNameCombinedWithId]
        public string Name { get; set; }
    }
}
