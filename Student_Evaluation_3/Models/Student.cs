using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class Student : User
    {
        public User User { get; set; }
        public int StudentID { get; set; }
        public DateTime GraduationYear { get; set; }
        public string PhoneNumber { get; set; }
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
