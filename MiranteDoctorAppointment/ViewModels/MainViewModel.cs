using Mirante.Domain.Models;
using MiranteDoctorAppointment.Commands;
using MiranteDoctorAppointment.Stores;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiranteDoctorAppointment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly AppointmentStore _store;

        public ObservableCollection<DoctorAppointment> Appointments => _store.Appointments;

        private DoctorAppointment? _selectedAppointment;
        public DoctorAppointment? SelectedAppointment
        {
            get => _selectedAppointment;
            set 
            { 
                _selectedAppointment = value; 
                OnPropertyChanged();
                
                // Update input fields when selecting an appointment
                if (value != null)
                {
                    FirstName = value.FirstName;
                    LastName = value.LastName;
                    PatientName = value.PatientName;
                    Specialty = value.Specialty;
                    
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(PatientName));
                    OnPropertyChanged(nameof(Specialty));
                }
            }
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }

        public MainViewModel(AppointmentStore store)
        {
            _store = store;
            AddCommand = new RelayCommand(AddAppointment);
            DeleteCommand = new RelayCommand(DeleteAppointment, () => SelectedAppointment != null);
            UpdateCommand = new RelayCommand(UpdateAppointment, () => SelectedAppointment != null);
        }

        private void AddAppointment()
        {
            var newAppointment = new DoctorAppointment
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                PatientName = this.PatientName,
                Specialty = this.Specialty
            };
            _store.AddAppointment(newAppointment);

            // Clear inputs
            FirstName = LastName = PatientName = Specialty = string.Empty;
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(PatientName));
            OnPropertyChanged(nameof(Specialty));
        }

        private void DeleteAppointment()
        {
            if (SelectedAppointment != null)
                _store.DeleteAppointment(SelectedAppointment);
        }

        private void UpdateAppointment()
        {
            if (SelectedAppointment != null)
            {
                // Update the selected appointment with current input values
                SelectedAppointment.FirstName = FirstName;
                SelectedAppointment.LastName = LastName;
                SelectedAppointment.PatientName = PatientName;
                SelectedAppointment.Specialty = Specialty;
                
                _store.UpdateAppointment(SelectedAppointment);
                
                // Refresh the DataGrid to show updated values
                OnPropertyChanged(nameof(Appointments));
            }
        }
    }
}
