using DAL;
using ENTITIES.Entities;
using ENTITIES.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Service layer for handling booking-related operations
    /// </summary>
    public class BookingService
    {
        BookingRepository br = new BookingRepository();

        /// <summary>
        /// Get all bookings mapped to BookingViewModel
        /// </summary>
        /// <returns>List of BookingViewModel</returns>
        // In your BookingService class or controller method
        public List<BookingVM> GetAllBookingsService()
        {
            var bookings = br.GetAllBookingsRepo();

            // Map domain models to BookingViewModel
            var bvm = bookings.Select(b => new BookingVM
            {
                BookingID = b.BookingID,
                PatientName = b.Patients.PatientName,
                DoctorName = b.Doctors.DoctorName,
                AvailabilityTime = b.Availabilities.AvailabilityTime
                // Map other properties as needed
            }).ToList();

            return bvm;
        }


        /// <summary>
        /// Get booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>Booking entity</returns>
        public Bookings GetBookingByIDService(int id)
        {
            return br.GetBookingByIDRepo(id);
        }

        /// <summary>
        /// Add a new booking
        /// </summary>
        /// <param name="bookingFormData">Booking data</param>
        /// <returns>Success or error message</returns>
        public string AddBookingService(Bookings bookingFormData)
        {
            return br.AddBooking(bookingFormData);
        }

        /// <summary>
        /// Update an existing booking
        /// </summary>
        /// <param name="bookingFormData">Updated booking data</param>
        /// <returns>Success or error message</returns>
        public string UpdateBookingService(Bookings bookingFormData)
        {
            return br.UpdateBookingRepo(bookingFormData);
        }

        /// <summary>
        /// Delete a booking
        /// </summary>
        /// <param name="patID">Patient ID</param>
        /// <returns>Success or error message</returns>
        public string DeleteBookingService(int patID)
        {
            return br.DeleteBookingRepo(patID);
        }

        /// <summary>
        /// Get available times for a doctor
        /// </summary>
        /// <param name="doctor">Doctor name</param>
        /// <returns>List of available times</returns>
        public List<string> GetAvailableTimesService(string doctor)
        {
            try
            {
                return br.GetAvailableTimesRepo(doctor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching available times: " + ex.Message);
            }
        }

        /// <summary>
        /// Get list of doctors
        /// </summary>
        /// <returns>List of doctor names</returns>
        public List<string> GetDoctorsService()
        {
            try
            {
                return br.GetDoctorsRepo();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching doctors: " + ex.Message);
            }
        }
    }
}
