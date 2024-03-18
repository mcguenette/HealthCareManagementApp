using DAL;
using ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingService
    {
       BookingRepository br = new BookingRepository();

        public List<Booking> GetAllBookingsService()
        {
            return br.GetAllBookingsRepo();
        }

        public Booking GetBookingByIDService(int id)
        {
            return br.GetBookingByIDRepo(id);
        }

        public string AddBookingService(Booking bookingFormData)
        {
            return br.AddBooking(bookingFormData);
        }

        public string UpdateBookingService(Booking bookingFormData)
        {
            return br.UpdateBookingRepo(bookingFormData);
        }

        public string DeleteBookingService(int patID)
        {
            return br.DeleteBookingRepo(patID);
        }

        public List<string> GetAvailableTimesService(string doctor)
        {
            try
            {
                return br.GetAvailableTimes(doctor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching available times: " + ex.Message);
            }
        }
    }
}
