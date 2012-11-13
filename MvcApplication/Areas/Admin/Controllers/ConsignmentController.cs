using System.Linq;
using System.Web.Mvc;
using DomainService.Enumerations;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ConsignmentModels;

namespace MVCApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConsignmentController : CheckModelIsNullController
    {
        private readonly IConsignmentPresentationService consignmentPresentationService;
        private readonly IProductPresentationService productPresentationService;

        public ConsignmentController(IConsignmentPresentationService consignmentPresentationService, IProductPresentationService productPresentationService)
        {
            this.consignmentPresentationService = consignmentPresentationService;
            this.productPresentationService = productPresentationService;
        }

        public ActionResult Index()
        {
            return View(consignmentPresentationService.LoadConsignmentIndexModel());
        }

        public ActionResult Add()
        {
            return Edit(default(long));
        }

        public ActionResult Edit(long id)
        {
            var model = consignmentPresentationService.LoadConsignmentEditModel(id);
            if (model.Status == ConsignmentStatus.Waiting)
            {
                return View("Edit", model);
            }
                
            return RedirectToAction("Details", new { id });
        }

        public ActionResult Details(long id)
        {
            return View(consignmentPresentationService.LoadConsignmentDetailsModel(id));
        }

        [HttpPost]
        public ActionResult Edit(ConsignmentEditModel consignmentEditModel)
        {
            if (ModelState.IsValid)
            {
                consignmentPresentationService.SaveConsignmentEditModel(consignmentEditModel, MvcApplication.LoggedInUser);
                return RedirectToAction("Index"); 
            }

            return View("Edit", consignmentEditModel);
        }

        [OutputCache(Duration = 0, NoStore = false)]
        public JsonResult ProductNames(string term)
        {
            return Json(productPresentationService.LoadProductsForTerm(term).Select(p => new { value = p.Name }), JsonRequestBehavior.AllowGet);
        }
    }
}