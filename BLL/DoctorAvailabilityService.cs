using DAL;
using ENTITIES.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoctorAvailabilityService
    {
        DoctorAvailabilityRepository dar = new DoctorAvailabilityRepository();
        public List<DoctorAvailabilityVM> GetDoctorAvailabilityForBooking()
        {
            return dar.GetAllDoctorsAvailabilitiesRepo();
        }

        public string UpdateDoctorAvailability(Dictionary<int, List<DateTime>> doctorAvailabilities)
        {
            return dar.UpdateDoctorAvailabilityRepo(doctorAvailabilities);
        }
    }
}
