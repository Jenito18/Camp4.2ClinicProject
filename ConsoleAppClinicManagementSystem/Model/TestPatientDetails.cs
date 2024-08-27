using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class TestPatientDetails
    {
        public int TPID { get; set; }
        public string SampleStatus { get; set; }
        public string Result { get; set; }
        public string NormalRange { get; set; }
        public int AppointId { get; set; }//foriegn key
        public int PatientId { get; set; }//foriegn key
        public int TestId { get; set; }//foriegn key
        public int ConsultationId { get; set; }//foriegn key


        //Navigate property as object oriented

        public Patient Patient { get; set; }

        public Appointment Appointment { get; set; }

        public Test Test { get; set; }

        public Consultation Consultation { get; set; }

        //constructor

        public TestPatientDetails() { }

        public TestPatientDetails(int tpid, string sampleStatus, string result, string normalRange, int appointId,
                                  int patientId, int testId, int consultationId)
        {
            TPID = tpid;
            SampleStatus = sampleStatus;
            Result = result;
            NormalRange = normalRange;
            AppointId = appointId;
            PatientId = patientId;
            TestId = testId;
            ConsultationId = consultationId;
        }
    }
}
