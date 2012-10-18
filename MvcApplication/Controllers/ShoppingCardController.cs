using System.Web.Mvc;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MVCApplication.Controllers
{
    public class ShoppingCardController : CheckModelIsNullController
    {
        public ShoppingCardController(IOrderPresentationService orderPresentationService)
        {
            OrderPresentationService = orderPresentationService;
        }

        public IOrderPresentationService OrderPresentationService { get; private set; }

        [HttpGet]
        public ActionResult AddProduct(long id)
        {
            OrderPresentationService.AddProductToShoppingCard(id, 1);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(OrderPresentationService.LoadShoppingCard(1));
        }
    }
}
