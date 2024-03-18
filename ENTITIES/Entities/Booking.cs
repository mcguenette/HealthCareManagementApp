using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; } // Navigation property for Patient

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; } // Navigation property for Doctor

        // Remove the ForeignKey attribute for AvailabilityID
        // Remove the AvailabilityID property since it's not needed here

        [ForeignKey("Availability")]
        public int AvailabilityID { get; set; }
        public virtual Availability Availability { get; set; }

    }
}
