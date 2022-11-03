using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        internal List<Teacher> teachers = new();

        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
            errorMessage = "";

            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service!.GetCourse(id);
                if (course != null)
                {
                    courseDto = ConvertToDTO(course);
                }

                teachers = service!.GetAllTeachersForKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void OnPost()
        {
            errorMessage = "";
            teachers = service!.GetAllTeachersForKey();

            courseDto.Id = int.Parse(Request.Form["id"]);
            courseDto.description = Request.Form["description"];
            courseDto.teacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.UpdateCourse(courseDto);
                Response.Redirect("/Courses/Index");

            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private CourseDTO ConvertToDTO(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                description = course.description!.Trim()
            };
        }
    }
}
