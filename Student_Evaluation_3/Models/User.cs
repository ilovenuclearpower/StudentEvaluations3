using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Student_Evaluation_3.Models
{
    public enum Role
    {
        Student, Instructor, Coordinator, Chairman
    }
    public class User
    {
        public int id { get; set; }
        public Role Role { get; set; }
        private string Password { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public List<Course> Courses { get; set; }
    }
}
