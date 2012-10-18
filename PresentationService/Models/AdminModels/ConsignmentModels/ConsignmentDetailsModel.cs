using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.AdminModels.ConsignmentModels
{
    public class ConsignmentDetailsModel
    {
        public ConsignmentDetailsModel(Consignment consignment)
        {
            if (consignment == null)
            {
                throw new ArgumentNullException("consignment");
            }

            ProductNameToCountDictionary = consignment.IncomingProducts.ToDictionary(p => p.Product.Name, p => p.Count);
        }

        public Dictionary<string, long> ProductNameToCountDictionary { get; private set; }
    }
}
