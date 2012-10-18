using PresentationService.Models.ShoppingCard;

namespace PresentationService.Interfaces
{
    public interface IOrderPresentationService : IBasePresentationService
    {
        void PayOrder(long userId);

        void CompleteOrder(long userId);

        ShoppingCardModel LoadShoppingCard(long userId);

        /// <summary>
        /// Add product to Order for the specified user
        /// This method will create a new order with 'Pending' status, or use existed order with this status
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"> </param>
        void AddProductToShoppingCard(long productId, long userId);
    }
}