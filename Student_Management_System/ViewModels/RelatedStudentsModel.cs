using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Management_System.Models;


namespace Student_Management_System.ViewModels
{
    public class RelatedStudentsModel
    {

        public IEnumerable<StudentDetails> RelatedStudentsList { get; set; }

        public IEnumerable<Subject> RelatedSubjectsList { get; set; }
        public StudentDetails student { get; set; }
    }
}
