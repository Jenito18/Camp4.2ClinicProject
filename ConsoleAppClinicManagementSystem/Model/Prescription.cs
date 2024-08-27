using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public string Symptoms { get; set; }
        public string Notes { get; set; }
        public int AppointId { get; set; }//foriegn key

        //Navigate property as object oriented

        public Appointment Appointment { get; set; }

        //constructor

        public Prescription() { }

        public Prescription(int prescriptionId, string symptoms, string notes, int appointId)
        {
            PrescriptionId = prescriptionId;
            Symptoms = symptoms;
            Notes = notes;
            AppointId = appointId;
        }
    }
}
