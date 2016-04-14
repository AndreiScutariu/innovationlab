using System.Security.Principal;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}