using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Management_System.Models;

namespace Student_Management_System.Pages.StudentPage
{
    public class StudentdetailsModel : PageModel
    {
        private readonly IStudentRespository student;
        public StudentdetailsModel(IStudentRespository _student)
        {
            student = _student;
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        //static int _id;
        //public PageResult OnGet(int id)
        //{
        //    _id = id;
        //    Student = student.GetStudentDetails(id);
        //    return Page();
        //}

        public PageResult OnGet()
        {
           
            Student = student.GetStudentDetails(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            Student.Id = id;
            student.UpdateStudent(Student);

            return RedirectToPage("ShowAllStudents");
        }
    }
}
