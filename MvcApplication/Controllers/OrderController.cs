using MVCApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MVCApplication.Controllers
{
    public class OrderController : CheckModelIsNullController
    {
        public OrderController(IOrderPresentationService orderPresentationService)
        {
            OrderPresentationService = orderPresentationService;
        }

        public IOrderPresentationService OrderPresentationService { get; private set; }
    }
}
