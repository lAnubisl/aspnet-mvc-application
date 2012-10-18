using System;

namespace PresentationService.Models.AdminModels.ConsignmentModels.Items
{
    public class ConsignmentIndexItemModel
    {
        public ConsignmentIndexItemModel(long consignmentId, DateTime dateLoad, string userEmail, long countProducts, long countDifferentProducts)
        {
            ConsignmentId = consignmentId;
            DateLoad = dateLoad;
            UserEmail = userEmail;
            CountProducts = countProducts;
            CountDifferentProducts = countDifferentProducts;
        }

        public long ConsignmentId { get; private set; }

        public DateTime DateLoad { get; private set; }

        public string UserEmail { get; private set; }

        public long CountProducts { get; private set; }

        public long CountDifferentProducts { get; private set; }
    }
}
