using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class GroupAssignment
    {
        public int GroupAssignmentID { get; set; }
        public int InstructorID { get; set; }
        public int FacultyGroupID { get; set; }


        public ICollection<FacultyGroup> FacultyGroups { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
