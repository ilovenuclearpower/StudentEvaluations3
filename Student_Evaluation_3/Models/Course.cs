using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public User Instructor { get; set; }
        public List<User> Students { get; set; }
        public List<Evaluation> Evals { get; set; }

        
    }
}
