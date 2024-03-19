using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    public class Availability2
    {
        [Key]
        public int AvailabilityID { get; set; }

        public DateTime AvailabilityTime { get; set; }

        // Navigation property for Bookings
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
