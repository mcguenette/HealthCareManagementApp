using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.ViewModels
{
    public class BookingVM
    {
        public int BookingID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AvailabilityTime { get; set; }
        public DateTime AvailabilityDate { get; set; }
    }
}
