using System;
using System.Collections.Generic;
using System.Linq;
using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ConsignmentModels.Items;

namespace PresentationService.Models.AdminModels.ConsignmentModels
{
    public class ConsignmentIndexModel
    {
        private readonly IEnumerable<ConsignmentIndexItemModel> consignments;

        public ConsignmentIndexModel(IEnumerable<Consignment> consignments)
        {
            if (consignments == null)
            {
                throw new ArgumentNullException("consignments");
            }

            this.consignments = consignments.Select(p => new ConsignmentIndexItemModel(p.Id, p.CreationDate, p.User.Email, p.IncomingProducts.Sum(ip => ip.Count), p.IncomingProducts.Count));
        }

        public IEnumerable<ConsignmentIndexItemModel> Consignments 
        {
            get
            {
                return this.consignments;
            }
        }
    }
}