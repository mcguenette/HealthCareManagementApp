using BLL;
using ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementApp.Controllers
{
    public class DoctorController : Controller
    {
        DoctorService ds = new DoctorService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var response = ds.GetAllDoctorsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterDoctor([FromBody] Doctors DoctorFormData)
        {
            var response = ds.AddDoctorService(DoctorFormData);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetDoctorByID(int id)
        {
            var docById = ds.GetDoctorByIDService(id);

            return Json(docById);
        }

        [HttpPost]
        public IActionResult UpdateDoctor([FromBody] Doctors DoctorFormData)
        {
            var DoctorToUpdated = ds.UpdateDoctorService(DoctorFormData);
            return Json(DoctorToUpdated);
        }

        [HttpPost]
        public IActionResult DeleteDoctor([FromBody] int patID)
        {
            try
            {
                var response = ds.DeleteDoctorService(patID);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }
    }
}
