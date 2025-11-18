using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Framework.DTOs
{
    public class DoctorAppointmentDto
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
    }
}
