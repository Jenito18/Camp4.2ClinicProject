using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class MedicinePatient
    {
        public int MPID { get; set; }
        public string Dosage { get; set; }
        public int Duration { get; set; }
        public int PatientId { get; set; }//foriegn key
        public int AppointId { get; set; }//foriegn key
        public int MedicineId { get; set; }//foriegn keyy
        public int ConsultationId { get; set; }//foriegn key
        public int PrescriptionId { get; set; }//foriegn key


        //Navigate property as object oriented

        public Patient Patient { get; set; }

        public Appointment Appointment { get; set; }

        public Medicine Medicine { get; set; }

        public Consultation Consultation { get; set; }

        public Prescription Prescription { get; set; }

        //constructor

        public MedicinePatient() { }

        public MedicinePatient(int mpid, string dosage, int duration, int patientId, int appointId,
                                      int medicineId, int consultationId, int prescriptionId)
        {
            MPID = mpid;
            Dosage = dosage;
            Duration = duration;
            PatientId = patientId;
            AppointId = appointId;
            MedicineId = medicineId;
            ConsultationId = consultationId;
            PrescriptionId = prescriptionId;
        }
    }
}
