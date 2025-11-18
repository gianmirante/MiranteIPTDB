using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Mirante.Framework.MiranteCFramework.DbContext;
using Mirante.Domain.Models;

namespace MiranteDoctorAppointment.Stores
{

    public class AppointmentStore
    {
        private readonly AppDbContext _context;

        public ObservableCollection<DoctorAppointment> Appointments { get; } = new();

        public AppointmentStore(AppDbContext context)
        {
            _context = context;
            LoadAppointments();
        }

        public void LoadAppointments()
        {
            Appointments.Clear();
            foreach (var appt in _context.DoctorAppointments)
                Appointments.Add(appt);
        }

        public void AddAppointment(DoctorAppointment appointment)
        {
            _context.DoctorAppointments.Add(appointment);
            _context.SaveChanges();
            Appointments.Add(appointment);
        }

        public void DeleteAppointment(DoctorAppointment appointment)
        {
            _context.DoctorAppointments.Remove(appointment);
            _context.SaveChanges();
            Appointments.Remove(appointment);
        }

        public void UpdateAppointment(DoctorAppointment appointment)
        {
            var existingAppointment = _context.DoctorAppointments.Find(appointment.DoctorId);
            if (existingAppointment != null)
            {
                existingAppointment.FirstName = appointment.FirstName;
                existingAppointment.LastName = appointment.LastName;
                existingAppointment.PatientName = appointment.PatientName;
                existingAppointment.Specialty = appointment.Specialty;
                _context.SaveChanges();
            }
        }
    }
}
