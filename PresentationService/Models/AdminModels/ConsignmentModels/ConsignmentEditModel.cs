using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using DomainService.Enumerations;
using PresentationService.Models.AdminModels.ConsignmentModels.Items;

namespace PresentationService.Models.AdminModels.ConsignmentModels
{
    public class ConsignmentEditModel
    {
        public ConsignmentEditModel(Consignment consignment)
        {
            if (consignment == null)
            {
                throw new ArgumentNullException("consignment");
            }

            Id = consignment.Id;
            Status = consignment.Status;
            if (consignment.IncomingProducts != null && consignment.IncomingProducts.Any())
            {
                Products = consignment.IncomingProducts.Select(p => new ConsignmentEditItemModel(p)).ToList();
            }
            else
            {
                Products = new List<ConsignmentEditItemModel>();
            }    
        }

        public IList<ConsignmentEditItemModel> Products { get; set; }

        public long Id { get; set; }

        public ConsignmentStatus Status { get; set; }
    }
}
