using ENTITIES.Context;
using ENTITIES.Entities;
using ENTITIES.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoctorAvailabilityRepository
    {

        PatientBookingContext pbc = new PatientBookingContext();
        public List<DoctorAvailabilityVM> GetAllDoctorsAvailabilitiesRepo()
        {
            //Create the collections of data
            List<Doctor> doctors = pbc.Doctors.ToList();
            List<Availability2> availabilities2 = pbc.Availabilities2.ToList();
            List<Booking> Bookings = pbc.Bookings.ToList();

            var doctorsAvailabilities2 = doctors.Select(d => new DoctorAvailabilityVM
            {
                DoctorId = d.DoctorID,
                DoctorName = d.DoctorName,
                AvailabilityTimes = availabilities2.Select(d => d.AvailabilityTime).ToList(),
                AvailabilityIds = availabilities2.Select(d => d.AvailabilityID).ToList(),
                Checked = availabilities2.Select(Availability2 => Bookings.Any(
                    Booking => Booking.AvailabilityID == Availability2.AvailabilityID && Booking.DoctorID == d.DoctorID)).ToList()

            }).ToList();
            return doctorsAvailabilities2;
        }


        public string UpdateDoctorAvailabilityRepo(Dictionary<int, List<DateTime>> doctorAvailabilities) 
        {
            //Check this.
            //pbc.Bookings.RemoveRange(pbc.Bookings.ToList());

            foreach (var item in doctorAvailabilities)
            {

                int doctorId = item.Key;

                foreach (var avaId in item.Value)
                {
                    var newdoctorAvailability = new DoctorAvailability
                    {
                        //AvailabilityID = avaId,
                        DoctorID = doctorId
                    };
                    //pbc.DoctorAvailability.Add(newdoctorAvailability);
                }

            }

            pbc.SaveChanges();
            return "success";
        }
    }
}
