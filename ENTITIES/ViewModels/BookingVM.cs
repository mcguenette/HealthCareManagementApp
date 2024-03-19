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
        public int? AvailabilityID { get; set; } // Use nullable int for AvailabilityID
        public DateTime? AvailabilityTime { get; set; } // Use nullable DateTime for AvailabilityTime
        public DateTime? AvailabilityDate { get; set; } // Use nullable DateTime for AvailabilityDate
    }

}
