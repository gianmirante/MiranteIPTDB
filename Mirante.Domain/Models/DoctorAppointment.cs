using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Domain.Models
{
    public class DoctorAppointment
    {
        [Key]
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
    }
}
