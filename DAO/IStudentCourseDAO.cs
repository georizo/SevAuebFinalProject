using SevStudentsApp.Models;

namespace SevStudentsApp.DAO
{
    public interface IStudentCourseDAO
    {
        void Insert(StudentCourse? studentCourse);
        StudentCourse? Delete(StudentCourse? studentCourse);
        List<StudentCourse> GetAll();
        List<Student> GetAllStudents();
        List<Course> GetAllCourses();
    }
}
