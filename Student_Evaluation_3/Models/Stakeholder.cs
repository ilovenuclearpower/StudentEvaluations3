using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class Stakeholder
    {
        public int StakeholderID { get; set; }
        public int CourseID { get; set; }
        public int GroupID { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<FacultyGroup> Instructors { get; set; }
    }
}
