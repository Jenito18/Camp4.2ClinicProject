using ConsoleAppClinicalCamp4Project.Repository;
using ConsoleAppClinicalCamp4Project.Service;
using ConsoleAppClinicManagementSystem.Model;
using ConsoleAppClinicManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem
{
    public class ClinicApp
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("****************************************************");
            Console.WriteLine("**            CLINIC MANAGEMENT SYSTEM            **");
            Console.WriteLine();
            Console.WriteLine("****************************************************");
            Console.WriteLine("|**            L  O  G  I  N    P  A  G  E       **|");
            Console.WriteLine("****************************************************");

            Console.WriteLine();
        lblUserName:
            Console.Write("Enter UserName : ");
            string userName = Console.ReadLine();

            bool isValidUserName = StaffValidation.IsValidUserName(userName);

            if (!isValidUserName)
            {
                Console.Clear();
                Console.WriteLine("Invalid User Name, Try again");
                goto lblUserName;
            }

            Console.Write("Enter Password : ");
            string password = StaffValidation.ReadPassword();

            bool isValidPassword = StaffValidation.IsValidPassword(password);

            if (!isValidPassword)
            {
                Console.WriteLine("Invalid Password, Try Again");
                goto lblUserName;
            }

            if (isValidUserName && isValidPassword)
            {
                IClinicService loginService = new ClinicServiceImpl(new ClinicRepositoryImpl());
                int roleId = await loginService.AuthenticateUserAsync(userName, password);

                if (roleId >= 1)
                {
                    switch (roleId)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.WriteLine("****************************************************");
                            Console.WriteLine("|**      R E C E P T I O N I S T  L O G I N       **|");
                            Console.WriteLine("****************************************************");
                            // Load Receptionist Menu
                            await ShowReceptionistDashboard();
                            break;

                        case 2:
                            ShowDoctorDashboard();
                            break;
                        default:
                            Console.WriteLine("Invalid role: ACCESS Denied");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Credential");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Receptionist Dashboard
        private static async Task ShowReceptionistDashboard()
        {
            Console.WriteLine("******   WELCOME TO RECEPTIONIST DASHBOARD    *******");
            Console.WriteLine("1. Patient Management");
            
            Console.WriteLine("2. Logout\n");
            Console.WriteLine("Choose an Option...");

            int recepOption = int.Parse(Console.ReadLine());

            IClinicService patientService = new ClinicServiceImpl(new ClinicRepositoryImpl());

            switch (recepOption)
            {
                case 1:
                    await ManagePatients(patientService);
                    break;
               
                case 2:
                    Console.WriteLine("Logging out...");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }

        // Method to manage patients
        public static async Task ManagePatients(IClinicService patientService)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("******   PATIENT MANAGEMENT    ******");
                Console.WriteLine();
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Update Patients");
                Console.WriteLine("3. Search Patient by PhoneNumber");
             
                Console.WriteLine("4. Book an Appointment");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddPatient(patientService);
                        break;
                    case "2":
                        await UpdatePatient(patientService);
                        break;
                    case "3":
                        await ViewPatientByPhoneNumber(patientService);
                        break;
                   
                    case "4":
                        await BookAppointment(patientService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong choice! Please enter again...");
                        break;
                }
            }
        }

        // AddPatient Method
        private static async Task AddPatient(IClinicService patientService)
        {
            Patient patient = new Patient();

            // Patient FirstName
            while (true)
            {
                Console.WriteLine("Enter Patient FirstName:");
                patient.FirstName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(patient.FirstName) && Regex.IsMatch(patient.FirstName, @"^[a-zA-Z\s]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try again...Please ensure the name contains only letters and spaces.");
                }
            }

            // Patient LastName
            while (true)
            {
                Console.WriteLine("Enter Patient LastName:");
                patient.LastName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(patient.LastName) && Regex.IsMatch(patient.LastName, @"^[a-zA-Z\s]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try again...Please ensure the name contains only letters and spaces.");
                }
            }

            // Patient PhoneNumber
            while (true)
            {
                Console.WriteLine("Enter Patient PhoneNumber:");
                patient.PhoneNumber = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(patient.PhoneNumber) && Regex.IsMatch(patient.PhoneNumber, @"^\d{10}$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for PhoneNumber. Please enter a valid 10-digit number.");
                }
            }

            // Patient Email (Optional)
            while (true)
            {
                Console.WriteLine("Enter Patient Email (Optional):");
                patient.Email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(patient.Email) || Regex.IsMatch(patient.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Email. Please enter a valid email address.");
                }
            }

            // Address
            Console.WriteLine("Enter Address:");
            patient.Address = Console.ReadLine();

            // Patient DOB
            while (true)
            {
                Console.WriteLine("Enter Patient DOB (yyyy-mm-dd):");
                string dobInput = Console.ReadLine();

                if (DateTime.TryParse(dobInput, out DateTime dob) && dob <= DateTime.Today)
                {
                    patient.DOB = dob;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for DOB. Please enter a valid date in yyyy-mm-dd format, and ensure it's not a future date.");
                }
            }

            // Patient BloodGroup
            while (true)
            {
                Console.WriteLine("Enter Patient BloodGroup:");
                patient.BloodGroup = Console.ReadLine().ToUpper();

                string[] validBloodGroups = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };

                if (Array.Exists(validBloodGroups, bg => bg == patient.BloodGroup))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for BloodGroup. Please enter a valid blood group (e.g., A+, O-, etc.).");
                }
            }
            while (true)
            {
                Console.WriteLine("Enter Gender:");
                patient.Gender = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(patient.Gender) && Regex.IsMatch(patient.Gender, @"^[a-zA-Z\s]+$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try again...Please ensure the correct gender entered.");
                }
            }
            // Exception Handling
            try
            {
                await patientService.AddPatientAsync(patient);
                Console.WriteLine("Patient added successfully.");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add patient: {ex.Message}");
            }
        }

        // Update Patient Details by PhoneNumber
        private static async Task UpdatePatient(IClinicService patientService)
        {
            // Get Patient Phone Number
            Console.WriteLine("Enter Patient PhoneNumber:");
            string phoneNumber = Console.ReadLine();

            // Exit if no phone number is provided
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Patient PhoneNumber is required...");
                return;
            }

            // Retrieve existing patient details using the phone number
            Patient patient = await patientService.GetPatientByPhoneNumberAsync(phoneNumber);

            // Exit if no patient is found
            if (patient == null)
            {
                Console.WriteLine("Patient not found with the provided PhoneNumber.");
                return;
            }

            // Update Patient Name
            while (true)
            {
                Console.WriteLine($"Current Name: {patient.FirstName} {patient.LastName}\n");
                Console.WriteLine("Enter Patient FirstName (Press Enter to keep current):");
                string firstNameInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstNameInput))
                {
                    break; // Keep the current name if input is empty
                }

                if (Regex.IsMatch(firstNameInput, @"^[a-zA-Z\s]+$"))
                {
                    // Update the patient name
                    patient.FirstName = firstNameInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.Name contains only letters and spaces.");
                }
            }

            // Update Patient LastName
            while (true)
            {
                Console.WriteLine($"Current LastName: {patient.LastName}\n");
                Console.WriteLine("Enter Patient LastName (Press Enter to keep current):");
                string lastNameInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(lastNameInput))
                {
                    break; // Keep the current last name if input is empty
                }

                if (Regex.IsMatch(lastNameInput, @"^[a-zA-Z\s]+$"))
                {
                    // Update the patient last name
                    patient.LastName = lastNameInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. LastName contains only letters and spaces.");
                }
            }

            // Update Address
            Console.WriteLine($"Current Address: {patient.Address}\n");
            Console.WriteLine("Enter Address (Press Enter to keep current):");
            string addressInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(addressInput))
            {
                patient.Address = addressInput; // Update address
            }

            // Exception Handling
            try
            {
                await patientService.UpdatePatientAsync(patient);
                Console.WriteLine("Patient updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update patient: {ex.Message}");
            }
        }

        // View Patient Details by PhoneNumber
        private static async Task ViewPatientByPhoneNumber(IClinicService patientService)
        {
            Console.WriteLine("Enter Patient PhoneNumber:");
            string phoneNumber = Console.ReadLine();

            // Getting patient details by using the phone number
            Patient patient = await patientService.GetPatientByPhoneNumberAsync(phoneNumber);

            if (patient != null)
            {
                Console.WriteLine("Patient found:");
                Console.WriteLine($"Name: {patient.FirstName} {patient.LastName}");
                Console.WriteLine($"PhoneNumber: {patient.PhoneNumber}");
                Console.WriteLine($"Email: {patient.Email}");
                Console.WriteLine($"Address: {patient.Address}");
                Console.WriteLine($"DOB: {patient.DOB:yyyy-MM-dd}");
                Console.WriteLine($"BloodGroup: {patient.BloodGroup}");
            }
            else
            {
                Console.WriteLine("Patient not found with the provided PhoneNumber.");
            }
        }


        // Book an Appointment
        //BookAppointment Method
        private static async Task BookAppointment(IClinicService patientService)
        {
            // Gather appointment details from the user
            Console.WriteLine("Enter Appointment Date (yyyy-mm-dd):");
            string dateInput = Console.ReadLine();
            DateTime appointDate;
            if (!DateTime.TryParse(dateInput, out appointDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.WriteLine("Enter Consultation Fee:");
            int tokenNumber;
            if (!int.TryParse(Console.ReadLine(), out tokenNumber))
            {
                Console.WriteLine("Invalid fee format.");
                return;
            }

            Console.WriteLine("Enter Patient ID:");
            int patientId;
            if (!int.TryParse(Console.ReadLine(), out patientId))
            {
                Console.WriteLine("Invalid Patient ID.");
                return;
            }

            Console.WriteLine("Enter Staff ID:");
            int staffId;
            if (!int.TryParse(Console.ReadLine(), out staffId))
            {
                Console.WriteLine("Invalid Staff ID.");
                return;
            }
            Console.WriteLine("Enter consultation ID:");
            int consultationId;
            if (!int.TryParse(Console.ReadLine(), out consultationId))
            {
                Console.WriteLine("Invalid consultation ID.");
                return;
            }

            // Create an Appointment object using the parameterized constructor
            Appointment appointment = new Appointment(appointDate, tokenNumber, patientId, staffId, consultationId);

            // Call the service to book the appointment
            int tokenNo = await patientService.BookAppointmentAsync(appointment);

            if (tokenNo > 0)
            {
                Console.WriteLine($"Appointment booked successfully! Token No: {tokenNo}");
            }
            else
            {
                Console.WriteLine("Failed to book appointment.");
            }
        }

        // Show Doctor Dashboard
        // DOCTOR DASHBOAR AFTER LOGIN
        private static async Task ShowDoctorDashboard()
        {
            bool dashboard = true;

            while (dashboard)
            {
                Console.WriteLine("*******    WELCOME TO DOCTOR DASHBOARD    ******");
                Console.WriteLine("1. List Patient Appointment");
                Console.WriteLine("2. Search Patient");
                Console.WriteLine("3. Logout\n");

                Console.Write("Select an Option: ");
                int doctorOption = int.Parse(Console.ReadLine());

                // Constructor Injection
                IClinicService patientService = new ClinicServiceImpl(new ClinicRepositoryImpl());

                switch (doctorOption)
                {
                    case 1:
                        await ListPatientAppointment(patientService);
                        break;
                    case 2:
                        await SearchPatientByToken(patientService);
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        dashboard = false;
                        break;
                    default:
                        Console.WriteLine("Invalid !, try again.");
                        break;
                }
            }
        }



        // View All Appointments
        private static async Task ListPatientAppointment(IClinicService patientService)
        {
            try
            {
                List<Appointment> appointments = await patientService.GetAllAppointmentsAsync();

                if (appointments != null && appointments.Count > 0)
                {
                    Console.WriteLine("*********************************         APPOINTMENTS          *************************************");

                    foreach (var appointment in appointments)
                    {
                        // Retrieve patient details to display
                        Patient patient = await patientService.GetPatientByIdAsync(appointment.PatientId);

                        // Calculate age
                        int age = DateTime.Now.Year - patient.DOB.Year;
                        if (DateTime.Now.DayOfYear < patient.DOB.DayOfYear)
                        {
                            age--;
                        }


                        Console.WriteLine($"Token No: {appointment.TokenNumber} || Date:{appointment.AppointDate} || Name: {patient.FirstName} {patient.LastName} || Age: {age} || Blood Group: {patient.BloodGroup}");
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("\nSelect Token No: ");
                    int tokenNo = int.Parse(Console.ReadLine());

                    var selectedAppointment = appointments.FirstOrDefault(a => a.TokenNumber == tokenNo);

                    if (selectedAppointment != null)
                    {
                        // Proceed with the selected appointment
                        Console.WriteLine($"Found Appointment with Token No: {selectedAppointment.TokenNumber}");

                        // Actions selected appointment
                        await ConsultPatient(patientService, tokenNo);


                    }
                    else
                    {
                        Console.WriteLine("Invalid Token No. Try again..");
                    }
                }
                else
                {
                    Console.WriteLine("No appointments found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving appointments: {ex.Message}");
            }


        }

        //Consult Patient from List of Appointment
        private static async Task ConsultPatient(IClinicService patientService, int tokenNumber)
        {
            try
            {
                // Retrieve patient details using the tokenNo
                var appointment = await patientService.GetAppointmentByTokenNoAsync(tokenNumber);
                if (appointment == null)
                {
                    Console.WriteLine("Appointment not found.");
                    return;
                }

                var patient = await patientService.GetPatientByIdAsync(appointment.PatientId);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }


                // Calculate age
                int age = DateTime.Now.Year - patient.DOB.Year;
                if (DateTime.Now.DayOfYear < patient.DOB.DayOfYear)
                {
                    age--;
                }

                // Print patient details
                Console.WriteLine("\n||****************************************************||");
                Console.WriteLine("|**           P A T I E N T || D E T A I L S           **| ");
                Console.WriteLine("||******************************************************||");
                Console.WriteLine($"Patient ID: {patient.PatientId}");
                Console.WriteLine($"Name: {patient.FirstName} {patient.LastName}");
                Console.WriteLine($"DOB: {age}");
                Console.WriteLine($"Blood Group: {patient.BloodGroup}");
                Console.WriteLine("||*******************************************************||");

                // Collect and validate consultation details
                string symptoms, diagnosis, medicine, labTest, note;

                Console.WriteLine("Enter Symptoms:");
                symptoms = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(symptoms))
                {
                    Console.WriteLine("Symptoms cannot be empty. Please enter the symptoms:");
                    symptoms = Console.ReadLine();
                }

                Console.WriteLine("Enter Diagnosis:");
                diagnosis = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(diagnosis))
                {
                    Console.WriteLine("Diagnosis cannot be empty. Please enter the diagnosis:");
                    diagnosis = Console.ReadLine();
                }

                Console.WriteLine("Enter Medicine:");
                medicine = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(medicine))
                {
                    Console.WriteLine("Medicine cannot be empty. Please enter the medicine:");
                    medicine = Console.ReadLine();
                }

                Console.WriteLine("Enter Lab Test (optional):");
                labTest = Console.ReadLine(); // Lab Test can be empty

                Console.WriteLine("Enter Note:");
                note = Console.ReadLine(); // Note is required

                // Validate Note
                if (string.IsNullOrWhiteSpace(note))
                {
                    Console.WriteLine("Note cannot be empty. Please enter the note:");
                    note = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(note))
                    {
                        Console.WriteLine("Note cannot be empty. Please enter the note:");
                        note = Console.ReadLine();
                    }
                }

                // Create a new ConsultationDetails instance
                var consultation = new Consultation(
                    tokenNumber,
                    patient.PatientId,
                    symptoms,
                    diagnosis,
                    medicine,
                    labTest,
                    note
                );

                // Save consultation details using the service
                await patientService.AddConsultationDetailsAsync(consultation);

                Console.WriteLine("Consultation details have been successfully saved.");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the consultation process: {ex.Message}");
            }
        }

        // Search Patient by Token No and consult directly
        private static async Task SearchPatientByToken(IClinicService patientService)
        {
            try
            {
                int tokenNo;
                while (true)
                {
                    Console.WriteLine("Enter the Token No to search and consult:");
                    string tokenNoInput = Console.ReadLine();

                    if (int.TryParse(tokenNoInput, out tokenNo))
                    {
                        var appointment = await patientService.GetAppointmentByTokenNoAsync(tokenNo);
                        if (appointment != null)
                        {
                            // Proceed with the selected appointment
                            await ConsultPatient(patientService, tokenNo);
                            break; // Exit the loop if a valid appointment is found
                        }
                        else
                        {
                            Console.WriteLine("Appointment not found. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Token No. Please enter a valid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the search process: {ex.Message}");
            }
        }
    }
}