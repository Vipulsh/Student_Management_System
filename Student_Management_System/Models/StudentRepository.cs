using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Models
{
    public class StudentRepository : IStudentRespository
    {
        private readonly string strConnectionString;
        

        public StudentRepository()
        {
            strConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Student_Management_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //_lstudents = new List<_Student>()
            //{
            //    new _Student(){ _StudentID=1,_TeacherID= 1 ,Name = "Cristiano Ronaldo",Subject ="Maths",Marks=100 },
            //    new _Student(){ _StudentID=2,_TeacherID= 1 ,Name = "Neymar Jr.",Subject ="Maths",Marks=80 },
            //    new _Student(){ _StudentID=3,_TeacherID= 2 ,Name = "Paul Pogba",Subject ="Maths",Marks=90 }
            //};
        }
        public IEnumerable<StudentDetails> GetStudents()
        {
            IEnumerable<StudentDetails> _lstudents;

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                _lstudents = con.Query<StudentDetails>("GetStudentDetails");
            }
            return _lstudents;
        }

        public int AddStudentMarks(StudentDetails student)
        {
            int rowAffected;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", student.StudentId);
                parameters.Add("@TeacherId", student.TeacherID);
                parameters.Add("@SubjectId", student.SubjectId);
                parameters.Add("@Marks", student.Marks);
                rowAffected = con.Execute("AddStudentMarks", parameters, commandType: CommandType.StoredProcedure);
            }
            return rowAffected;

        }

        public IEnumerable<StudentDetails> GetRelatedStudents(int id)
        {
            IEnumerable<StudentDetails> _lstudents;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                _lstudents = con.Query<StudentDetails>("GetStudent", parameter, commandType: CommandType.StoredProcedure);
            }
            return _lstudents;
        }

        public IEnumerable<Subject> GetRelatedSubjects(int id)
        {
            IEnumerable<Subject> _lsubjects;

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                _lsubjects = con.Query<Subject>("GetSubjectsByTeacher", parameter, commandType: CommandType.StoredProcedure);
            }
            return _lsubjects;
        }

        public IEnumerable<StudentDetails> GetSubjectToppers()
        {

            IEnumerable<StudentDetails> _lstudents;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                _lstudents = con.Query<StudentDetails>("GetSubjectToppers", commandType: CommandType.StoredProcedure);
            }
            return _lstudents;


        }

        public Student GetStudentDetails(int id)
        {
            Student _lstudent = new Student();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@StudentId", id);
                _lstudent = con.QuerySingle<Student>("GetStudentById", parameter, commandType: CommandType.StoredProcedure);

            }
            return _lstudent;
        }


        public int UpdateStudent(Student student)
        {

            int rowAffected;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", student.Id);
                parameters.Add("@Name", student.Name);
                parameters.Add("@Age", student.Age);
                rowAffected = con.Execute("UpdateStudent", parameters, commandType: CommandType.StoredProcedure);
            }
            return rowAffected;
        }

        public int DeleteStudent(int id)
        {

            int rowAffected;
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", id);
                rowAffected = con.Execute("DeleteStudent", parameters, commandType: CommandType.StoredProcedure);
            }
            return rowAffected;
        }
    }
}
