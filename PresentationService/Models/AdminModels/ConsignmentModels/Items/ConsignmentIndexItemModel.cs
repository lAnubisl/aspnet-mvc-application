using System;

namespace PresentationService.Models.AdminModels.ConsignmentModels.Items
{
    public class ConsignmentIndexItemModel
    {
        private readonly long consignmentId, countProducts, countDifferentProducts;
        private readonly string userEmail;
        private readonly DateTime dateLoad;

        internal ConsignmentIndexItemModel(long consignmentId, DateTime dateLoad, string userEmail, long countProducts, long countDifferentProducts)
        {
            this.consignmentId = consignmentId;
            this.dateLoad = dateLoad;
            this.userEmail = userEmail;
            this.countProducts = countProducts;
            this.countDifferentProducts = countDifferentProducts;
        }

        public long ConsignmentId
        {
            get
            {
                return this.consignmentId;
            }
        }

        public DateTime DateLoad
        {
            get
            {
                return this.dateLoad;
            }
        }

        public string UserEmail
        {
            get
            {
                return this.userEmail;
            }
        }

        public long CountProducts
        {
            get
            {
                return this.countProducts;
            }
        }

        public long CountDifferentProducts
        {
            get
            {
                return this.countDifferentProducts;
            }
        }
    }
}
