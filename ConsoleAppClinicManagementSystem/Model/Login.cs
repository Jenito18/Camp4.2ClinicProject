using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int StaffId { get; set; }//foriegn key

        //Navigate property as object oriented

        public Staff Staff { get; set; }

        //constructor

        public Login() { }

        public Login(int loginId, string userName, string password, int staffId)
        {
            LoginId = loginId;
            UserName = userName;
            Password = password;
            StaffId = staffId;
        }


    }
}
