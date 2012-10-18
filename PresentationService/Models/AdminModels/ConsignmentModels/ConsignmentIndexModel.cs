using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ConsignmentModels.Items;

namespace PresentationService.Models.AdminModels.ConsignmentModels
{
    public class ConsignmentIndexModel
    {
        public ConsignmentIndexModel(IEnumerable<Consignment> consignments)
        {
            if (consignments == null)
            {
                throw new ArgumentNullException("consignments");
            }

            Consignments = consignments.Select(p => new ConsignmentIndexItemModel(p.Id, p.CreationDate, p.User.Email, p.IncomingProducts.Sum(ip => ip.Count), p.IncomingProducts.Count));
        }

        public IEnumerable<ConsignmentIndexItemModel> Consignments { get; private set; }
    }
}
