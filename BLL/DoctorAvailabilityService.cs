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
        public List<DoctorAvailabilityVM> GetDoctorAvailability()
        {
            return dar.GetAllDoctorsAvailabilitiesRepo();
        }

        public string UpdateDoctorAvailability(Dictionary<int, List<int>> doctorAvailabilities)
        {
            return dar.UpdateDoctorAvailabilityRepo(doctorAvailabilities);
        }
    }
}
