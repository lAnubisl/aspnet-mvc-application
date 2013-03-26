using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;

namespace PresentationService.Models.AdminModels.ConsignmentModels
{
    public class ConsignmentDetailsModel
    {
        private readonly IDictionary<string, long> productNameToCount;

        internal ConsignmentDetailsModel(Consignment consignment)
        {
            if (consignment == null)
            {
                throw new ArgumentNullException("consignment");
            }

            this.productNameToCount = consignment.IncomingProducts.ToDictionary(p => p.Product.Name, p => p.Count);
        }

        public IDictionary<string, long> ProductNameToCountDictionary
        {
            get
            {
                return this.productNameToCount;
            }
        }
    }
}