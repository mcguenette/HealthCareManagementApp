using BLL;
using ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HealthCareManagementApp.Controllers
{
    public class BookingController : Controller
    {
        BookingService bs = new BookingService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var response = bs.GetAllBookingsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterBooking([FromBody] Booking bookingFormData)
        {
            var response = bs.AddBookingService(bookingFormData);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetBookingByID(int id)
        {
            var pacById = bs.GetBookingByIDService(id);

            return Json(pacById);
        }

        [HttpPost]
        public IActionResult UpdateBooking([FromBody] Booking bookingFormData)
        {
            var patientToUpdated = bs.UpdateBookingService(bookingFormData);
            return Json(patientToUpdated);
        }

        [HttpPost]
        public IActionResult DeleteBooking([FromBody] int patID)
        {
            try
            {
                var response = bs.DeleteBookingService(patID);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(string doctor)
        {
            try
            {
                // Call your business logic layer method to get available times based on the selected doctor
                List<string> availableTimes = bs.GetAvailableTimesService(doctor);

                // Return the available times as JSON data
                return Json(availableTimes);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return Json(new { error = ex.Message });
            }
        }
    }
}
