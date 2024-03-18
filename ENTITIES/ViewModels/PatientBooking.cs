using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.ViewModels
{
    public class PatientBooking
    {
        public int PatientID { get; set; }

        public string PatientName { get; set; }

        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public DateTime BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public int AvailabilityID { get; set; }

        public List<string> Bookings { get; set; }


        public List<int> BookingIDs { get; set; }

        public List<bool> Checked { get; set; }
    }
}
