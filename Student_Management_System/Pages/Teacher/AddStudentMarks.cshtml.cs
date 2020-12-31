using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Management_System.Models;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Pages.Teacher
{ 
    public class AddStudentMarksModel : PageModel
    {

        private readonly IStudentRespository _student;


        public AddStudentMarksModel(IStudentRespository student)
        {
            _student = student;
        }

        [BindProperty]
        public RelatedStudentsModel relatedStudents { get; set; }

        
        static int _id;

       
        public PageResult OnGet(int id)
        {
            relatedStudents = new RelatedStudentsModel()
            {

                RelatedStudentsList = _student.GetRelatedStudents(id),
                RelatedSubjectsList = _student.GetRelatedSubjects(id),
                student = new StudentDetails()
            };
            _id = id;
            return Page();
        }

        public IActionResult OnPost(StudentDetails student)
        {
           
            relatedStudents.student.TeacherID = _id;
            _student.AddStudentMarks(relatedStudents.student);
            return RedirectToPage("../StudentPage/ShowAllStudents");

            //return Page();
        }
    }
}
