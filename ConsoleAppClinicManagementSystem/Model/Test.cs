using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Model
{
    public class Test
    {

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int Rate { get; set; }

        //constructor

        public Test() { }

        public Test(int testId, string testName, int rate)
        {
            TestId = testId;
            TestName = testName;
            Rate = rate;
        }
    }
}
