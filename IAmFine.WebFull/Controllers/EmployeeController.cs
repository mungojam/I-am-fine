using System.Web.Mvc;

namespace IAmFine.Web.Controllers
{
    public class EmployeeController : Controller
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