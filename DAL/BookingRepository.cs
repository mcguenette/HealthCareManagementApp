using ENTITIES.Context;
using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Repository class for handling booking-related data access logic.
    /// </summary>
    /// 
    public class BookingRepository
    {
        /// <summary>
        /// The database context instance for accessing booking data.
        /// </summary>

        PatientBookingContext pbc = new PatientBookingContext();

        /// <summary>
        /// Constructor to initialize the repository with the database context.
        /// </summary>
        public BookingRepository()
        {
            pbc = new PatientBookingContext();
        }

        /// <summary>
        /// Get all bookings from the database.
        /// </summary>
        /// <returns>A list of all bookings.</returns>
        public List<Bookings> GetAllBookingsRepo()
        {
            return pbc.Bookings.ToList();
        }

        /// <summary>
        /// Add a new booking to the database.
        /// </summary>
        /// <param name="bookingFormData">The booking data to be added.</param>
        /// <returns>A string indicating the operation result (success or error).</returns>
        public string AddBooking(Bookings bookingFormData)
        {
            if (bookingFormData != null)
            {
                pbc.Bookings.Add(bookingFormData);
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }

        /// <summary>
        /// Get a booking by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the booking to retrieve.</param>
        /// <returns>The booking entity if found, otherwise null.</returns>
        public Bookings GetBookingByIDRepo(int id)
        {
            return pbc.Bookings.FirstOrDefault(x => x.BookingID == id);
        }

        /// <summary>
        /// Update an existing booking in the database.
        /// </summary>
        /// <param name="bookingFormData">The updated booking data.</param>
        /// <returns>A string indicating the operation result (success or error).</returns>
        public string UpdateBookingRepo(Bookings bookingFormData)
        {
            Bookings bookToBeUpdated = pbc.Bookings.FirstOrDefault(x => x.BookingID == bookingFormData.BookingID);

            if (bookToBeUpdated != null)
            {
                bookToBeUpdated.BookingID = bookingFormData.BookingID;
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }

        /// <summary>
        /// Delete a booking from the database by its ID.
        /// </summary>
        /// <param name="bookID">The ID of the booking to delete.</param>
        /// <returns>A string indicating the operation result (success or error).</returns>
        public string DeleteBookingRepo(int bookID)
        {
            var response = "";
            try
            {
                Bookings bookToBeDeleted = pbc.Bookings.FirstOrDefault(x => x.BookingID == bookID);
                if (bookToBeDeleted != null)
                {
                    pbc.Bookings.Remove(bookToBeDeleted);
                    pbc.SaveChanges();
                    response = "success";
                }
                else
                {
                    response = "error: Booking not found";
                }
            }
            catch (Exception ex)
            {
                response = $"error: {ex.Message}";
            }
            return response;
        }

        /// <summary>
        /// Get available times for appointments based on the selected doctor's name.
        /// </summary>
        /// <param name="doctorName">The name of the doctor to fetch available times for.</param>
        /// <returns>A list of available times as strings.</returns>
        public List<Availabilities> GetAvailableTimesRepo(string doctorName)
        {
            try
            {
                List<Availabilities> availabilities = pbc.Availabilities
                    .Include(a => a.Doctors) // Include Doctors navigation property
                    .Where(a => a.Doctors.DoctorName == doctorName)
                    .ToList();

                return availabilities;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching available times: " + ex.Message);
            }
        }


        /// <summary>
        /// Get all doctors' names from the database.
        /// </summary>
        /// <returns>A list of all doctors' names.</returns>
        public List<string> GetDoctorsRepo()
        {
            try
            {
                // Ensure that the Doctors table is included in the query to fetch doctor names
                var doctors = pbc.Doctors.Include(d => d.Bookings).Select(d => d.DoctorName).ToList();

                // Log the number of doctors retrieved
                Console.WriteLine($"Number of doctors retrieved: {doctors.Count}");

                return doctors;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Error fetching doctors: " + ex.Message);
                throw new Exception("Error fetching doctors: " + ex.Message);
            }
        }

    }
}
