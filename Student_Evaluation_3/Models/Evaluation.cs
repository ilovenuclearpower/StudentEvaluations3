using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Evaluation_3.Models
{
    public class Evaluation
    {
        public int id { get; set; }
        public User instructor { get; set; }
        public Course Course { get; set; }

        public Dictionary<string, string> Fields { get; set; }

    }
}
