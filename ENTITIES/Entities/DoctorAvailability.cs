using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class DoctorAvailability
    {
        [Key]
        public int DoctorAvailibilityID { get; set; }

        [ForeignKey("Availabilities")]
        public int AvailabilityID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctors Doctors { get; set; }

        public virtual Availabilities Availabilities { get; set;}
    }
}
