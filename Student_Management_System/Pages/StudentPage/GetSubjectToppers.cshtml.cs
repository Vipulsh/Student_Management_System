using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Management_System.Models;
using Student_Management_System.ViewModels;

namespace Student_Management_System.Pages.StudentPage
{
    public class GetSubjectToppersModel : PageModel
    {
        private IStudentRespository _students;
        public GetSubjectToppersModel(IStudentRespository students)
        {
            _students = students;
        }


        public RelatedStudentsModel studentdetails;

        public PageResult OnGet()
        {
            studentdetails = new RelatedStudentsModel()
            {

                RelatedStudentsList = _students.GetSubjectToppers()
            };
            return Page();
        }
    }
}
