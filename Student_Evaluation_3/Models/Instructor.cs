using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class Instructor
    {
        public User User { get; set; }
        public string InstructorID { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        private int Salary { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
