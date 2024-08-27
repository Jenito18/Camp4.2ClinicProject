
using ClassLibrarySQLServerConnectionLibraray;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppClinicManagementSystem.Model;


namespace ConsoleAppClinicalCamp4Project.Repository
{
    public class ClinicRepositoryImpl : IClinicRepository
    {


        // Retrieve Connection String from App.Config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Cswin"].ConnectionString;

        // Insert
        public async Task AddPatientAsync(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            try
            {
                using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertPatient", conn))
                    {
                        // Command Type
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Input Parameters
                        command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                        command.Parameters.AddWithValue("@LastName", patient.LastName);
                        command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", (object)patient.Email ?? DBNull.Value); // Handle null values
                        command.Parameters.AddWithValue("@Address", patient.Address);
                        command.Parameters.AddWithValue("@DOB", patient.DOB);
                        command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                        command.Parameters.AddWithValue("@Gender", (object)patient.Gender ?? DBNull.Value); // Handle null values

                        await command.ExecuteNonQueryAsync();
                    }
                }
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




        // Insert Details after Update
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            try
            {
                using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_UpdatePatient", conn))
                    {
                        // Command Type
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Input Parameters
                        command.Parameters.AddWithValue("@Phone", patient.PhoneNumber);
                        command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                        command.Parameters.AddWithValue("@LastName", patient.LastName);
                        command.Parameters.AddWithValue("@Email", patient.Email);
                        command.Parameters.AddWithValue("@Address", patient.Address);
                        command.Parameters.AddWithValue("@DOB", patient.DOB);
                        command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        // Return the updated patient
                        if (rowsAffected > 0)
                        {
                            return patient;
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                            return null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }



        public async Task<Patient> GetPatientByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required.", nameof(phoneNumber));

            Patient patient = null;

            try
            {
                using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("ssp_GetPatientDetailsByPhone", conn))
                    {
                        // Command Type
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Input Parameter
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                patient = new Patient
                                {
                                    PatientId = reader["PatientId"] as int? ?? default,
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    DOB = reader["DOB"] as DateTime? ?? default,
                                    BloodGroup = reader["BloodGroup"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return patient;
        }

        /*      // View all Patients
              public async Task<List<Patient>> GetAllPatientsAsync()
              {
                  List<Patient> patients = new List<Patient>();

                  try
                  {
                      using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(_connectionString))
                      {
                          using (SqlCommand command = new SqlCommand("sp_GetAllPatients", conn))
                          {
                              // Command Type
                              command.CommandType = System.Data.CommandType.StoredProcedure;

                              using (SqlDataReader reader = await command.ExecuteReaderAsync())
                              {
                                  while (await reader.ReadAsync())
                                  {
                                      Patient patient = new Patient
                                      {
                                          PatientId = reader["PatientId"] as int? ?? default,
                                          FirstName = reader["FirstName"].ToString(),
                                          LastName = reader["LastName"].ToString(),
                                          PhoneNumber = reader["Phone"].ToString(),
                                          Email = reader["Email"].ToString(),
                                          Address = reader["Address"].ToString(),
                                          DOB = reader["DOB"] as DateTime? ?? default,
                                          BloodGroup = reader["BloodGroup"].ToString()
                                      };

                                      patients.Add(patient);
                                  }
                              }
                          }
                      }
                  }
                  catch (SqlException ex)
                  {
                      Console.WriteLine($"Database error: {ex.Message}");
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine($"An error occurred: {ex.Message}");
                  }

                  return patients;
              }
        */


        //BookAppointment

        public async Task<int> BookAppointmentAsync(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_BookAppointments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters matching the stored procedure
                    command.Parameters.AddWithValue("@AppointDate", appointment.AppointDate);
                    command.Parameters.AddWithValue("@TokenNumber", appointment.TokenNumber);
                    command.Parameters.AddWithValue("@ConsultationId", appointment.ConsultationId);
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@StaffId", appointment.StaffId);

                    // Output parameter for AppointmentId
                    SqlParameter outputParam = new SqlParameter("@AppointmentId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    // Open the connection and execute the command
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    // Retrieve the output value
                    int appointmentId = (int)outputParam.Value;
                    return appointmentId;
                }
            }
        }


        public async Task DeletePatientAsync(string patientId)
        {
            // Implementation for deleting patient
            // Example:
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                string query = "DELETE FROM Patients WHERE PatientId = @PatientId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }



        public async Task<Patient> GetPatientByIdAsync(string patientId)
        {
            // Implementation for getting patient by ID
            // Example:
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                string query = "SELECT * FROM Patients WHERE PatientId = @PatientId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new Patient
                            {
                                // Map data from reader to Patient object
                                // Example:
                                PatientId = reader["PatientId"] as int? ?? default,
                                FirstName = reader["Name"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString()
                                // Add other properties here
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<int> AuthenticateUserAsync(string userName, string password)
        {
            // SQL connection
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(_connectionString))
            {
                // SQL command
                using (SqlCommand command = new SqlCommand("sp_GetUserPass", conn))
                {
                    // Command Type
                    command.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    // Output parameter 
                    SqlParameter roleIdParam = new SqlParameter("@RoleId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(roleIdParam);

                    /* 
                     * Output parameters: Even though ExecuteNonQueryAsync() does not return any rows,
                     * it can still interact with output parameters or return values set by the stored procedure.
                     */
                    await command.ExecuteNonQueryAsync();

                    // Returning the output parameter's value
                    return (int)roleIdParam.Value;
                }
            }
        }

        // Doctor Module--------

        //Get all appointments for doctor
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            var appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllAppointments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var appointment = new Appointment
                            {
                                TokenNumber = reader.GetInt32(reader.GetOrdinal("TokenNo")),
                                AppointDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),

                            };
                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }



        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            Patient patient = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetPatientById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            patient = new Patient
                            {
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                                BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"))
                            };
                        }
                    }
                }
            }

            return patient;
        }


        public async Task<Appointment> GetAppointmentByTokenNoAsync(int tokenNo)
        {
            Appointment appointment = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAppointmentByTokenNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TokenNo", tokenNo);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            appointment = new Appointment
                            {
                                TokenNumber = reader.GetInt32(reader.GetOrdinal("TokenNo")),
                                AppointDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId"))
                            };
                        }
                    }
                }
            }

            return appointment;
        }



        public async Task AddConsultationDetailsAsync(Consultation consultationDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertConsultationDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TokenNo", consultationDetails.TokenNumber);
                        command.Parameters.AddWithValue("@PatientId", consultationDetails.PatientId);
                       
                        command.Parameters.AddWithValue("@Symptoms", consultationDetails.Symptoms);
                        command.Parameters.AddWithValue("@Diagnosis", consultationDetails.Diagnosis);
                        command.Parameters.AddWithValue("@Medicine", consultationDetails.Medicine);
                        command.Parameters.AddWithValue("@LabTest", (object)consultationDetails.LabTest ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Note", consultationDetails.Note);

                        // Open the connection
                        await connection.OpenAsync();

                        // Execute the stored procedure; no need to return a value
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
                throw; // Rethrow or handle as appropriate
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow or handle as appropriate
            }
        }

      



    }
}

    

        


    

