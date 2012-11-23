using MvcApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MvcApplication.Controllers
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
