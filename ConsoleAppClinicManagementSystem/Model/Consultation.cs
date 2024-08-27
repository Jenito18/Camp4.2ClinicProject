using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Consultation
    {
        public int TokenNumber { get; set; }
        public int PatientId { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public string LabTest { get; set; }
        public string Note { get; set; }

        // Constructor with all parameters
        public Consultation(int tokenNumber, int patientId, string symptoms, string diagnosis, string medicine, string labTest, string note)
        {
            TokenNumber = tokenNumber;
            PatientId = patientId;
            Symptoms = symptoms;
            Diagnosis = diagnosis;
            Medicine = medicine;
            LabTest = labTest;
            Note = note;
        }

        // Optional: Parameterless constructor if needed
        public Consultation() { }
    }


}

