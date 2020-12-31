using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public interface IStudentRespository
    {
        
        IEnumerable<StudentDetails> GetStudents();
        int AddStudentMarks(StudentDetails student);

        IEnumerable<StudentDetails> GetRelatedStudents(int id);

        IEnumerable<Subject> GetRelatedSubjects(int id);

        IEnumerable<StudentDetails> GetSubjectToppers();

        Student GetStudentDetails(int id);

        int UpdateStudent (Student student);

        int DeleteStudent(int student);

    }
}
