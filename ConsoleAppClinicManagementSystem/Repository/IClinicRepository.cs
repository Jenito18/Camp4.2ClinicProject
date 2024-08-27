
using ConsoleAppClinicManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicalCamp4Project.Repository
{
    public interface IClinicRepository
    {
        //Insert Patient
        Task AddPatientAsync(Patient patient);

        //Update Patient
        Task<Patient> UpdatePatientAsync(Patient patient);

        //Search
        Task<Patient> GetPatientByPhoneNumberAsync(string phoneNumber);

        //List all Patients
     //   Task<List<Patient>> GetAllPatientsAsync();

        // book Appointment
        Task<int> BookAppointmentAsync(Appointment appointment);

        Task DeletePatientAsync(string patientId);  // Add this method
        Task<Patient> GetPatientByIdAsync(string patientId);  // Add this method
        Task<int> AuthenticateUserAsync(string userName, string password);

        Task AddConsultationDetailsAsync(Consultation consultationDetails);

        Task<Patient> GetPatientByIdAsync(int patientId);

        Task<Appointment> GetAppointmentByTokenNoAsync(int tokenNumber);
        
        Task<List<Appointment>> GetAllAppointmentsAsync();

    }
}
