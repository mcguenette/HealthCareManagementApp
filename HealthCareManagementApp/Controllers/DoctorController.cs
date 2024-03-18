using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
