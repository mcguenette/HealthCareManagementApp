using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Doctors
    {
        [Key]
        public int DoctorID { get; set; }

        [MaxLength(50)]
        public string DoctorName { get; set; }

        [MaxLength(50)]
        public string DoctorEmail { get; set; }

        [MaxLength(50)]
        public string DoctorSpecialization { get; set; }

        // Navigation property for Bookings
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<Availabilities> Availabilities { get; set; }
    }
}
