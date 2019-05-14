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

        /// <summary>
        ///     查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Query()
        {
            var crud = new Models.CRUD();
            Transaction.Run(Businesses.CRUD.Query, crud);
            return Json(crud);
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Product product)
        {
            Transaction.Run(Businesses.CRUD.Update, product);
            return Json(product);
        }

        /// <summary>
        ///     儲存
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Product product)
        {
            Transaction.Run(Businesses.CRUD.Save, product);
            return Json(product);
        }
    }
}