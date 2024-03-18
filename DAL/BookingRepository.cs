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

        public List<Booking> GetAllBookingRepo()
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
                pacToBeUpdated.DoctorID = bookingFormData.DoctorID;
                pacToBeUpdated.AvailabilityTime = bookingFormData.AvailabilityTime;
                pacToBeUpdated.AvailabilityDate = bookingFormData.AvailabilityDate;

                //Mapper.Map(pac, pacToBeUpdated); Using automapper is only one line
                pbc.SaveChanges();
                return "success";
            }
            return "error";
        }

        public string DeletePatientRepo(int patID)
        {
            var response = "";
            try
            {
                Patient pacToBeDeleted = pbc.Patients.FirstOrDefault(x => x.PatientID == patID);
                if (pacToBeDeleted != null)
                {
                    pbc.Patients.Remove(pacToBeDeleted);
                    pbc.SaveChanges();
                    response = "success";
                }
                else
                {
                    response = "error: Patient not found";
                }
            }
            catch (Exception ex)
            {
                response = $"error: {ex.Message}";
            }
            return response;
        }
    }
}
