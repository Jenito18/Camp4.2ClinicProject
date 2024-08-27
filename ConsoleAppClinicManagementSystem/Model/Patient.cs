using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Patient
    {

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }


        //constructor

        public Patient() { }

        public Patient(int patientId, string firstName, string lastName, string phoneNumber, string email,
                       string address, DateTime dob, string bloodGroup, string gender)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            DOB = dob;
            BloodGroup = bloodGroup;
            Gender = gender;
        }

    }

    
}
