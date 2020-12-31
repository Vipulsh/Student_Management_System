using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Management_System.Models;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Pages.Students
{
    
    public class ShowAllStudentsModel : PageModel
    {
        private readonly IStudentRespository _student;

        public ShowAllStudentsModel(IStudentRespository student)
        {
            _student = student;
        }

        public RelatedStudentsModel Allstudents { get; set; }

        public PageResult OnGet()
        
        {
            Allstudents = new RelatedStudentsModel()
            {
                RelatedStudentsList = _student.GetStudents()
            };
            return Page();
        }

        public IActionResult OnPostEdit(int id)
        {
            return RedirectToPage("Studentdetails", new { id });
        }

        public IActionResult OnPostDelete(int id)
        {
            _student.DeleteStudent(id);
            return RedirectToPage("ShowAllStudents");
        }
    }
}
