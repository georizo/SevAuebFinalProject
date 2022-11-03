using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        internal List<Teacher> teachers = new();

        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
            try
            {
                teachers = service!.GetAllTeachersForKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void OnPost()
        {
            teachers = service!.GetAllTeachersForKey();

            courseDto.description = Request.Form["description"];
            courseDto.teacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.InsertCourse(courseDto);
                Response.Redirect("/Courses/Index");

            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
