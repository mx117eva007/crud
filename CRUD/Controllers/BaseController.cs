using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //TODO Log   
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            //TODO Log 
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //TODO Log 
        }
    }
}