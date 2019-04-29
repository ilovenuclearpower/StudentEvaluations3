﻿using System.Collections.Generic;

namespace Student_Evaluation_3.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public List<Student> Instructors { get; set; }
        public List<Instructor> Students { get; set; }
        public List<Evaluation> Evals { get; set; }

        
    }
}
