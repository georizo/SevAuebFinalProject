using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new();
        internal List<Student> students = new();

        public CreateModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
            try
            {
                students = service!.GetAllStudents();
                courses = service!.GetAllCourses();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void OnPost()
        {
            students = service!.GetAllStudents();
            courses = service!.GetAllCourses();
            errorMessage = "";

            try
            {

                studentCourseDto.studentId = int.Parse(Request.Form["studentid"]);
                studentCourseDto.courseId = int.Parse(Request.Form["courseid"]);

                service!.InsertStudentCourse(studentCourseDto);
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
