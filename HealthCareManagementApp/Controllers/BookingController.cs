using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementApp.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
