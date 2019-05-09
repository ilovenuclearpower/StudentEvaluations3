using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    [Serializable]
    public class Evaluation
    {
        public int EvaluationID { get; set; }
        public int StakeholderID { get; set; }
        public ICollection<Stakeholder> stakeholders { get; set; }
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        [DisplayName("Why did you take this course?")]
        public String why_course { get; set; }
        [DisplayName("How many hours per week were spent studying outside of class?")] 
        public String hours_week { get; set; }
        [DisplayName("How does this course connect with your life?")]
        public String life_connection { get; set; }
        [DisplayName("What grade did you get in this course?")]
        public String grade { get; set; }
        [DisplayName("Did the course have clearly stated goals?")]
        public String clear_goals { get; set; }
        [DisplayName("Were assignments helpful to your learning process?")]
        public String helpful_assignments { get; set; }
        [DisplayName("Was required reading helpful (if applicable)?")]
        public String reading_helpful { get; set; }
        [DisplayName("Were instructional materials of high quality and relevant?")]
        public String relevant_materials { get; set; }
        [DisplayName("Did the course challenge you to learn?")]
        public String challenged_learn { get; set; }
        [DisplayName("Did the outline or syllabus clearly state the course’s content, grading criteria, and other expectations?")]
        public String clear_syllabus { get; set; }
        [DisplayName("Was the instructor prepared for class?")]
        public String instructor_prepared { get; set; }
        [DisplayName("Did the instructor demonstrate knowledge of the subject?")]
        public String instructor_knowledgeable { get; set; }
        [DisplayName("Did the instructor use effective teaching strategies?")]
        public String effective_teaching { get; set; }
        [DisplayName("Did instructor returne assignments in a timely manner?")]
        public String timely_manner { get; set; }
        [DisplayName("Did instructor provided suggestions for improvement?")]
        public String suggested_improvement { get; set; }
        [DisplayName("Was grading fair and consistent with the outline or syllabus?")]
        public String grading_fair { get; set; }
        [DisplayName("Was the instructor enthusiastic about teaching the course?")]
        public String enthusiastic_teaching { get; set; }
        [DisplayName("Did instructor show concern for the student’s understanding?")]
        public String concern_understanding { get; set; }
        [DisplayName("Was there opportunity for instructor/student interaction?")]
        public String instructor_interaction { get; set; }
        [DisplayName("Did the instructor encourage different points of view when appropriate?")]
        public String different_views { get; set; }
        [DisplayName("I could have improved by doing...")]
        public String student_improved { get; set; }
        [DisplayName("I was successful in...")]
        public String successful_in { get; set; }
        [DisplayName("The course was good because...")]
        public String good_because { get; set; }
        [DisplayName("The course could be improved by...")]
        public String improved_by { get; set; }
        [DisplayName("The instructor did a good job of...")]
        public String good_job { get; set; }
        [DisplayName("The instructor's teaching could be improved by...")]
        public String teaching_improved { get; set; }

    }
}
