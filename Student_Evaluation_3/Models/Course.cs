using System.Collections.Generic;

namespace Student_Evaluation_3.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public List<User> Instructors { get; set; }
        public List<User> Students { get; set; }
        public List<Evaluation> Evals { get; set; }

        
    }
}
