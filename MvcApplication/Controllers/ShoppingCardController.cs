using System.Web.Mvc;
using MvcApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MvcApplication.Controllers
{
    public class ShoppingCardController : CheckModelIsNullController
    {
        public ShoppingCardController(IOrderPresentationService orderPresentationService)
        {
            OrderPresentationService = orderPresentationService;
        }

        public IOrderPresentationService OrderPresentationService { get; private set; }

        public ActionResult AddProduct(long id)
        {
            OrderPresentationService.AddProductToShoppingCard(id, 1);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View(OrderPresentationService.LoadShoppingCard(1));
        }
    }
}