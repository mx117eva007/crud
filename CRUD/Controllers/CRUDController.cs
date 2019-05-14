using System.Web.Mvc;
using CRUD.Delegates;

namespace CRUD.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            var crud = new Models.CRUD();
            Transaction.Run(Businesses.CRUD.Index, crud);
            return View(crud);
        }
    }
}