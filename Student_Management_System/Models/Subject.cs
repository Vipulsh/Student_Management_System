using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public string Name { get; set; }
    }
}
