using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService service;

        internal List<Course> courses = new();
        internal List<Student> students = new();
        public DeleteModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }
        
        internal StudentCourseDTO studentCourseDTO = new();
        public string errorMessage = "";
        public void OnGet()
        {
            try
            {
                StudentCourse? studentCourse;

                int sid = int.Parse(Request.Query["sid"]);
                int cid = int.Parse(Request.Query["cid"]);

                studentCourseDTO.studentId = sid;
                studentCourseDTO.courseId = cid;

                studentCourse = service.DeleteStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentCourses/Index");
                
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
