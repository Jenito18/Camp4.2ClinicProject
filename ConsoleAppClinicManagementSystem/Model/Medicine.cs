using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Medicine
    {

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Unit { get; set; }

        //constructor

        public Medicine() { }

        public Medicine(int medicineId, string medicineName, int price, DateTime expiryDate, int unit)
        {
            MedicineId = medicineId;
            MedicineName = medicineName;
            Price = price;
            ExpiryDate = expiryDate;
            Unit = unit;
        }
    }
}
