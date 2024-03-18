﻿using ENTITIES.Context;
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
                pacToBeUpdated.DoctorID = bookingFormData.DoctorID;
                pacToBeUpdated.AvailabilityTime = bookingFormData.AvailabilityTime;
                pacToBeUpdated.AvailabilityDate = bookingFormData.AvailabilityDate;

                //Mapper.Map(pac, pacToBeUpdated); Using automapper is only one line
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
    }
}