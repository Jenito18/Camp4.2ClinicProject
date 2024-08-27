using ConsoleAppClinicManagementSystem.Model;
using ConsoleAppClinicalCamp4Project.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsoleAppClinicalCamp4Project.Service
{
    public class ClinicServiceImpl : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;

        // Constructor Injection
        public ClinicServiceImpl(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        // Insert Patient
        public async Task AddPatientAsync(Patient patient)
        {
            try
            {
                await _clinicRepository.AddPatientAsync(patient);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Update Patient
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            await _clinicRepository.UpdatePatientAsync(patient);
            return patient;
        }

        // Get Patient by Phone Number
        public async Task<Patient> GetPatientByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty", nameof(phoneNumber));

            return await _clinicRepository.GetPatientByPhoneNumberAsync(phoneNumber);
        }

        // List all Patients
      /*  public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _clinicRepository.GetAllPatientsAsync();
        }
      */
        // Book Appointment
        public async Task<int> BookAppointmentAsync(Appointment appointment)
        {
            return await _clinicRepository.BookAppointmentAsync(appointment);
        }

        // Delete Patient Details
        public async Task DeletePatientAsync(string patientId)
        {
            try
            {
                await _clinicRepository.DeletePatientAsync(patientId);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Get Patient by ID (Code)
        public async Task<Patient> GetPatientByIdAsync(string patientId)
        {
            if (string.IsNullOrWhiteSpace(patientId))
                throw new ArgumentException("Patient ID cannot be null or empty", nameof(patientId));

            return await _clinicRepository.GetPatientByIdAsync(patientId);
        }

        public Task<int> AuthenticateUserAsync(string userName, string password)
        {
            return _clinicRepository.AuthenticateUserAsync(userName, password);
        }
       //doctor module
        public async Task AddConsultationDetailsAsync(Consultation consultationDetails)
        {
            if (consultationDetails == null) throw new ArgumentNullException(nameof(consultationDetails));

            await _clinicRepository.AddConsultationDetailsAsync(consultationDetails);
        }

        public async Task<Appointment> GetAppointmentByTokenNoAsync(int tokenNumber)    
        {
            return await _clinicRepository.GetAppointmentByTokenNoAsync(tokenNumber);
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _clinicRepository.GetPatientByIdAsync(patientId);
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _clinicRepository.GetAllAppointmentsAsync();
        }
    }
}
