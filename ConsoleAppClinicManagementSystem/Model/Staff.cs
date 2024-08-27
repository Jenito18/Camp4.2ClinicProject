using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public bool IsActive { get; set; }
        public int QID { get; set; }//foreign key
        public int RoleId { get; set; }//foreign key

        //Navigate property as object oriented
        public Role Role { get; set; }

        public Qualification Qualification { get; set; }


        //constructor

        public Staff() { }

        public Staff(int staffId, string firstName, string lastName, String phoneNumber, string email,
                     string address, DateTime dob, string bloodGroup, bool isActive, int qid, int roleId)
        {
            StaffId = staffId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            DOB = dob;
            BloodGroup = bloodGroup;
            IsActive = isActive;
            QID = qid;
            RoleId = roleId;
        }
    }
}
