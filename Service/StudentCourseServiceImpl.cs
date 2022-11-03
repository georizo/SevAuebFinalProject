using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public class StudentCourseServiceImpl : IStudentCourseService
    {
        private readonly IStudentCourseDAO dao;

        public StudentCourseServiceImpl(IStudentCourseDAO dao)
        {
            this.dao = dao;
        }

        public void InsertStudentCourse(StudentCourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                StudentCourse? studentCourse = Convert(dto);
                dao.Insert(studentCourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto)
        {

            if (dto is null) return null;

            try
            {
                StudentCourse? studentCourse = Convert(dto);
                return dao.Delete(studentCourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public List<StudentCourse> GetAllStudentCourses()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse>();
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAllCourses();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAllStudents();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }


        private StudentCourse? Convert(StudentCourseDTO dto)
        {
            if (dto == null) return null;

            return new StudentCourse()
            {
                studentId = dto.studentId,
                courseId = dto.courseId
            };
        }

    }
}
