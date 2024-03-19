using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Bookings
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("Patients")]
        public int PatientID { get; set; }
        public virtual Patients Patients { get; set; }

        [ForeignKey("Doctors")]
        public int DoctorID { get; set; }
        public virtual Doctors Doctors { get; set; }

        [ForeignKey("Availabilities")]
        public int AvailabilityID { get; set; }
        public virtual Availabilities Availabilities { get; set; }

    }
}
