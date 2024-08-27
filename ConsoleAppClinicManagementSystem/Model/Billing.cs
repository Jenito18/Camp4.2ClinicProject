using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Billing
    {
        public int BillId { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TotalAmount { get; set; }
        public int AppointId { get; set; } //foriegn key
        
        public int MPId { get; set; }//foriegn key
        public int TPId { get; set; }//foriegn key

        //Navigate property as object oriented

        public Appointment Appointment { get; set; }

        public MedicinePatient MedicinePatient { get; set; }

        public TestPatientDetails TestPatientDetails { get; set; }

        //constructor

        public Billing() { }

        public Billing(int billId, string paymentStatus, DateTime paymentDate, int totalAmount, int appointId, int mpId, int tpId)
        {
            BillId = billId;
            PaymentStatus = paymentStatus;
            PaymentDate = paymentDate;
            TotalAmount = totalAmount;
            AppointId = appointId;
            MPId = mpId;
            TPId = tpId;
        }

    }
}
