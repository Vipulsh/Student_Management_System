using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class StudentDetails
    {

        
        public int Id { get; set; }

        public int TeacherID { get; set; }

        public string Name { get; set; }

        public string SubjectId { get; set; }

        public string Subject { get; set; }

        public int StudentId { get; set; }

        public int Marks { get; set; }

    }
}
