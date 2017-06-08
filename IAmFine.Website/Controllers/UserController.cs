using Microsoft.AspNetCore.Mvc;

namespace IAmFine.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Help()
        {
            return View();
        }
        
    }
}