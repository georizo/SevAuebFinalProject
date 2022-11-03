using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentCourseService
    {
        /// <summary>
        /// Returns all StudentCourses records.
        /// </summary>
        /// <returns>All StudentCourses</returns>
        List<StudentCourse> GetAllStudentCourses();
        /// <summary>
        /// Inserts a StudentCourse record.
        /// </summary>
        /// <param name="dto">The DTO object input from user</param>
        void InsertStudentCourse(StudentCourseDTO? dto);
        /// <summary>
        /// Deletes a Student record.
        /// </summary>
        /// <param name="dto">The DTO object input from user</param>
        /// <returns></returns>
        StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);
        /// <summary>
        /// Returns all courses.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Course> GetAllCourses();
        /// <summary>
        /// Returns all students.
        /// </summary>
        /// <returns></returns>
        List<Student> GetAllStudents();
    }
}
