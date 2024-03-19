using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Availabilities
    {
        [Key]
        public int AvailabilityID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public virtual Doctors Doctors { get; set; } // Navigation property for Doctor

        //public DateTime AvailabilityDate { get; set; }

        public DateTime AvailabilityTime { get; set; }

        // Navigation property for Bookings
        //public virtual ICollection<Bookings> Bookings { get; set; }

        public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }

    }
}
