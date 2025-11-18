using Mirante.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirante.Domain.Commands
{
    public class AddDoctorAppointmentCommand
    {
        public DoctorAppointment Appointment { get; set; }

        public AddDoctorAppointmentCommand(DoctorAppointment appointment)
        {
            Appointment = appointment;
        }
    }
}
