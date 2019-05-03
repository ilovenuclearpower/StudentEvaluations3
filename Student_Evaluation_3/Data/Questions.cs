using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Data
{
    public class Questions
    {
        string[,] surveyQuestions = new string[,]
        {
            {"Why did you take this course?", "why_course"},
        
            {"How many hours per week were spent studying outside of class?", "hours_week"},

            {"How does this course connect with your life?", "life_connection"},

	        {"What grade did you get in this course?", "grade_"},

	        {"Did the course have clearly stated goals?", "clear_goals"},

            {"Were assignments helpful to your learning process?", "helpful_assignments"},

            {"Was required reading helpful (if applicable)?", "reading_helpful"},

            {"Were instructional materials of high quality and relevant?", "relevant_materials"},

            {"Did the course challenge you to learn?", "challenged_learn"},

            {"Did the outline or syllabus clearly state the course’s content, grading criteria, and other expectations?", "clear_syllabus"},

            {"Was the instructor prepared for class?", "instructor_prepared"},

            {"Did the instructor demonstrate knowledge of the subject?", "instructor_knowledgeable"},

            {"Did the instructor use effective teaching strategies?", "effective_teaching"},

            {"Did instructor returne assignments in a timely manner?", "timely_manner"},

            {"Did instructor provided suggestions for improvement?", "suggested_imporvement"},

            {"Was grading fair and consistent with the outline or syllabus?", "grading_fair"},

            {"Was the instructor enthusiastic about teaching the course?", "enthusiastic_teaching"},

            {"Did instructor show concern for the student’s understanding?", "concern_understanding"},

            {"Was there opportunity for instructor/student interaction?", "instructor_interaction"},

            {"Did the instructor encourage different points of view when appropriate?", "different_views"},

            {"I could have improved by doing...", "student_improved"},

            {"I was successful in...", "successful_in"},

            {"The course was good because...", "good_because"},

            {"The course could be improved by...", "improved_by"},

            {"The instructor did a good job of...", "good_job"},

            {"The instructor's teaching could be improved by...", "teaching_improved"}
        };
    }
}
