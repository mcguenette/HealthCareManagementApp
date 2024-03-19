using System.ComponentModel.DataAnnotations;

namespace ENTITIES.Entities
{
    public class Patients
    {
        [Key]
        public int PatientID { get; set; }

        [MaxLength(50)]
        public string PatientName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
