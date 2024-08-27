using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Role
    {
        //fields

        public int RoleId { get; set; } 

        public string RoleName { get; set; }


        //constructor

        public Role() { }

        public Role(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }



    }
}
