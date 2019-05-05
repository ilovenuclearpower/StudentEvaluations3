using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    [Serializable]
    public class Evaluation
    {
        public int id { get; set; }
        public User instructor { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public String why_course { get; set; }
        public String hours_week { get; set; }
        public String life_connection { get; set; }
        public String grade { get; set; }
        public String clear_goals { get; set; }
        public String helpful_assignments { get; set; }
        public String reading_helpful { get; set; }
        public String relevant_materials { get; set; }
        public String challenged_learn { get; set; }
        public String clear_syllabus { get; set; }
        public String instructor_prepared { get; set; }
        public String instructor_knowledgeable { get; set; }
        public String effective_teaching { get; set; }
        public String timely_manner { get; set; }
        public String suggested_improvement { get; set; }
        public String grading_fair { get; set; }
        public String enthusiastic_teaching { get; set; }
        public String concern_understanding { get; set; }
        public String instructor_interaction { get; set; }
        public String different_views { get; set; }
        public String student_improved { get; set; }
        public String successful_in { get; set; }
        public String good_because { get; set; }
        public String improved_by { get; set; }
        public String good_job { get; set; }
        public String teaching_improved { get; set; }

    }
}
