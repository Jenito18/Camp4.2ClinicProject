using ConsoleAppClinicalCamp4Project.Repository;
using ConsoleAppClinicManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppClinicalCamp4Project.Service
{
    public interface IClinicService
    {
        // Insert Patient
        Task AddPatientAsync(Patient patient);

        // Update Patient
        Task<Patient> UpdatePatientAsync(Patient patient);

        // Get Patient by Phone Number
        Task<Patient> GetPatientByPhoneNumberAsync(string phoneNumber);

        // List all Patients
      //  Task<List<Patient>> GetAllPatientsAsync();

        // Book Appointment
        Task<int> BookAppointmentAsync(Appointment appointment);

        // Delete Patient Details
        Task DeletePatientAsync(string patientId);

        // Get Patient by ID (Code)
        Task<Patient> GetPatientByIdAsync(string patientId);
        Task<int> AuthenticateUserAsync(string userName, string password);

        Task<Appointment> GetAppointmentByTokenNoAsync(int tokenNumber);

        Task<Patient> GetPatientByIdAsync(int patientId);

        Task AddConsultationDetailsAsync(Consultation consultationDetails);

        Task<List<Appointment>> GetAllAppointmentsAsync();

        // Consultation
        // Task AddConsultationDetailsAsync(Consultation consultationDetails);
    }
}
