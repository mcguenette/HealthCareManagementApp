using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.ViewModels
{
    public class DoctorAvailabilityVM
    {
        public int DoctorID { get; set; }

        public string DoctorName { get; set; }

        public List<DateTime> AvailabilityTimes { get; set; }
        public List<int> AvailabilityIDs { get; set; }
        public List<bool> Checked { get; set; }
    }
}
