using ENTITIES.Context;
using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingRepository
    {
        PatientBookingContext pbc = new PatientBookingContext();

        public List<Booking> GetAllBookingsRepo()
        {
            return pbc.Bookings.ToList();
        }

        public string AddBooking(Booking bookingFormData)
        {
            if (bookingFormData != null)
            {
                pbc.Bookings.Add(bookingFormData);
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }
        public Booking GetBookingByIDRepo(int id)
        {
            return pbc.Bookings.FirstOrDefault(x => x.BookingID == id);
        }

        public string UpdateBookingRepo(Booking bookingFormData)
        {
            Booking pacToBeUpdated = pbc.Bookings.FirstOrDefault(x => x.BookingID == bookingFormData.BookingID);

            if (pacToBeUpdated != null)
            {
                pacToBeUpdated.PatientID = bookingFormData.PatientID;
                // Do not update DoctorID or AvailabilityID here
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }

        public string DeleteBookingRepo(int bookID)
        {
            var response = "";
            try
            {
                Booking pacToBeDeleted = pbc.Bookings.FirstOrDefault(x => x.BookingID == bookID);
                if (pacToBeDeleted != null)
                {
                    pbc.Bookings.Remove(pacToBeDeleted);
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
        public List<string> GetAvailableTimes(string doctorName)
        {
            try
            {
                // Example implementation - Replace with actual database query
                List<Availability> availabilities = pbc.Availabilities
                    .Where(a => a.Doctor.DoctorName == doctorName)
                    .ToList();

                // Convert the list of Availability objects to a list of string (available times)
                List<string> availableTimes = availabilities.Select(a => a.AvailabilityTime.ToString("HH:mm")).ToList();

                return availableTimes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching available times: " + ex.Message);
            }
        }
    }
}
