using BLL;
using ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementApp.Controllers
{
    public class DoctorController : Controller
    {
        DoctorService DoctorService = new DoctorService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var response = DoctorService.GetAllDoctorsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterDoctor([FromBody] Doctor DoctorFormData)
        {
            var response = DoctorService.AddDoctorService(DoctorFormData);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetDoctorByID(int id)
        {
            var docById = DoctorService.GetDoctorByIDService(id);

            return Json(docById);
        }

        [HttpPost]
        public IActionResult UpdateDoctor([FromBody] Doctor DoctorFormData)
        {
            var DoctorToUpdated = DoctorService.UpdateDoctorService(DoctorFormData);
            return Json(DoctorToUpdated);
        }

        [HttpPost]
        public IActionResult DeleteDoctor([FromBody] int patID)
        {
            try
            {
                var response = DoctorService.DeleteDoctorService(patID);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }
    }
}
