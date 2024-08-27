using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Qualification
    {
        //fields
        public int QID { get; set; }
        public string QualificationName { get; set; }

        //constructor

        public Qualification() { }

        public Qualification(int qid, string qualificationName)
        {
            QID = qid;
            QualificationName = qualificationName;
        }

    }
}
