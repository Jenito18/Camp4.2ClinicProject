using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Appointment
    {
        //fields

        public int AppointId { get; set; }
        public DateTime AppointDate { get; set; }
        public int TokenNumber { get; set; }
        public int ConsultationId { get; set; }//foriegn key
        public int PatientId { get; set; }//foriegn key
        public int StaffId { get; set; }//foriegn key


        //Navigate property as object oriented

        public Consultation Consultation { get; set; }
        public Patient Patient { get; set; }

        public Staff Staff { get; set; }

        //constructor

        public Appointment() { }

        public Appointment(int appointId, DateTime appointDate, int tokenNumber, int consultationId, int patientId, int staffId)
        {
            AppointId = appointId;
            AppointDate = appointDate;
            TokenNumber = tokenNumber;
            ConsultationId = consultationId;
            PatientId = patientId;
            StaffId = staffId;
        }

        public Appointment(DateTime appointDate, int tokenNumber, int patientId, int staffId, int consultationId)
        {
            AppointDate = appointDate;
            TokenNumber = tokenNumber;
            PatientId = patientId;
            StaffId = staffId;
            ConsultationId = consultationId;
        }
    }
}
