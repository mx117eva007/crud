using System.Web.Mvc;
using CRUD.Delegates;

namespace CRUD.Controllers
{
    public class CRUDController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query()
        {
            var crud = new Models.CRUD();
            Transaction.Run(Businesses.CRUD.Query, crud);
            return Json(crud);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            Transaction.Run(Businesses.CRUD.Update, product);
            return Json(product);
        }
    }
}