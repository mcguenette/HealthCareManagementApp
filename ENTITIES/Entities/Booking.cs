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
        public virtual Patient Patient { get; set; }

        // Remove the ForeignKey attribute for Doctor and Availability
        public virtual Doctor Doctor { get; set; }
        public virtual Availability Availability { get; set; }

    }
}
