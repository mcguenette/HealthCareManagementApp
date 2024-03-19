using BLL;
using ENTITIES.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HealthCareManagementApp.Controllers
{
    /// <summary>
    /// Controller for managing bookings
    /// </summary>
    public class BookingController : Controller
    {
        BookingService bs = new BookingService();

        /// <summary>
        /// Action method for displaying all bookings
        /// </summary>
        /// <returns>View with all bookings</returns>
        public IActionResult Index()
        {
            var bookings = bs.GetAllBookingsService();
            return View(bookings);
        }

        /// <summary>
        /// API endpoint to get all bookings
        /// </summary>
        /// <returns>JSON response with all bookings</returns>
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var response = bs.GetAllBookingsService();
            return Json(response);
        }

        /// <summary>
        /// API endpoint to register a new booking
        /// </summary>
        /// <param name="bookingFormData">Booking data</param>
        /// <returns>JSON response indicating success or error</returns>
        [HttpPost]
        public IActionResult RegisterBooking([FromBody] Bookings bookingFormData)
        {
            var response = bs.AddBookingService(bookingFormData);
            return Json(response);
        }

        /// <summary>
        /// API endpoint to get a booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>JSON response with the booking details</returns>
        [HttpGet]
        public IActionResult GetBookingByID(int bookID)
        {
            var bookByID = bs.GetBookingByIDService(bookID);
            return Json(bookByID);
        }

        /// <summary>
        /// API endpoint to update an existing booking
        /// </summary>
        /// <param name="bookingFormData">Updated booking data</param>
        /// <returns>JSON response indicating success or error</returns>
        [HttpPost]
        public IActionResult UpdateBooking([FromBody] Bookings bookingFormData)
        {
            var patientToUpdated = bs.UpdateBookingService(bookingFormData);
            return Json(patientToUpdated);
        }

        /// <summary>
        /// API endpoint to delete a booking
        /// </summary>
        /// <param name="bookingID">Booking ID</param>
        /// <returns>JSON response indicating success or error</returns>
        [HttpPost]
        public IActionResult DeleteBooking([FromBody] int bookingID)
        {
            try
            {
                var response = bs.DeleteBookingService(bookingID);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }

        /// <summary>
        /// API endpoint to get a list of doctors
        /// </summary>
        /// <returns>JSON response with the list of doctors</returns>
        public JsonResult GetDoctors()
        {
            try
            {
                var doctors = bs.GetDoctorsService();
                return Json(doctors);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// API endpoint to get available times for a doctor
        /// </summary>
        /// <param name="doctor">Doctor name</param>
        /// <returns>JSON response with available times</returns>
        public JsonResult GetAvailableTimes(string doctor)
        {
            try
            {
                var availableTimes = bs.GetAvailableTimesService(doctor);
                return Json(availableTimes);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
