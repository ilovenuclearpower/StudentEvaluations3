using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class FacultyGroup : User
    {
        public int FacultyGroupID { get; set; }
        public string GroupName { get; set; }
    }
}
