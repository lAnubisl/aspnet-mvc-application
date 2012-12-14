using DomainService.DomainModels;
using PresentationService.Models.AdminModels.ConsignmentModels;

namespace PresentationService.Interfaces.Admin
{
    public interface IConsignmentPresentationService : IBasePresentationService
    {
        ConsignmentIndexModel LoadConsignmentIndexModel();

        ConsignmentEditModel LoadConsignmentEditModel(long consignmentId);

        void SaveConsignmentEditModel(ConsignmentEditModel consignmentEditModel, long userId);

        ConsignmentDetailsModel LoadConsignmentDetailsModel(long consignmentId);
    }
}
