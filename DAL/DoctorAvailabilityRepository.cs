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
            List<Doctors> doctors = pbc.Doctors.ToList();
            List<Availability2> availabilities = pbc.Availabilities2.ToList();
            List<DoctorAvailability> doctorAvailabilities = pbc.DoctorAvailability.ToList();

            var doctorsAvailabilities = doctors.Select(d => new DoctorAvailabilityVM
            {
                DoctorId = d.DoctorID,
                DoctorName = d.DoctorName,
                AvailabilityTimes = availabilities.Select(d => d.AvailabilityTime).ToList(),
                AvailabilityIds = availabilities.Select(d => d.AvailabilityID).ToList(),
                Checked = availabilities.Select(Availability2 => doctorAvailabilities.Any(
                    da => da.AvailabilityID == Availability2.AvailabilityID && da.DoctorID == d.DoctorID)).ToList()

            }).ToList();
            return doctorsAvailabilities;
        }


        public string UpdateDoctorAvailabilityRepo(Dictionary<int, List<int>> doctorAvailabilities) 
        {
            

            foreach (var item in doctorAvailabilities)
            {
                int doctorId = item.Key;
                var daToRemove = pbc.DoctorAvailability.Where(b => b.DoctorID == doctorId).ToList();
                pbc.DoctorAvailability.RemoveRange(daToRemove);

                foreach (var avaId in item.Value)
                {
                    var newdoctorAvailability = new DoctorAvailability
                    {
                        AvailabilityID = avaId,
                        DoctorID = doctorId
                    };
                    pbc.DoctorAvailability.Add(newdoctorAvailability);
                }

            }

            pbc.SaveChanges();
            return "success";
        }
    }
}
