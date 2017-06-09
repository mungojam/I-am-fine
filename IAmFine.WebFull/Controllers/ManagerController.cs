using System.Web.Mvc;
using IAmFine.Data;

namespace IAmFine.Web.Controllers
{
    public class ManagerController : Controller
    {
        private AmFineService service = new AmFineService();

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            var employees = new EmployeeeViewModel
            {
                Employees = service.GetEmployees()
            };
            return View(employees);
        }

        // GET: Manager
        public ActionResult Coming()
        {
            return View();
        }
    }
}