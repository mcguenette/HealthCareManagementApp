using Azure;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementApp.Controllers
{
    public class DoctorAvailabilityController : Controller
    {
        DoctorAvailabilityService das = new DoctorAvailabilityService();
        public IActionResult Index()
        {
            var response = das.GetDoctorAvailability();
            return View(response);
        }

        [HttpPost]
        public IActionResult UpdateDoctorAvailabilities([FromBody] Dictionary<int, List<int>> doctorAvailabilities)
        {
            var response = das.UpdateDoctorAvailability(doctorAvailabilities);
            return View(response);
        }

    }
}
