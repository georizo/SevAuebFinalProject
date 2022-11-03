using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ICourseService
    {
        /// <summary>
        /// Creates a course record.
        /// </summary>
        /// <param name="dto">the DTO object that is converted to course object</param>
        void InsertCourse(CourseDTO? dto);
        /// <summary>
        /// Updates a course record.
        /// </summary>
        /// <param name="dto">the DTO object that is converted to course object</param>
        void UpdateCourse(CourseDTO? dto);
        /// <summary>
        /// Deletes a record.
        /// </summary>
        /// <param name="dto">the DTO object that is converted to course object</param>
        /// <returns>the deleted item</returns>
        Course? DeleteCourse(CourseDTO? dto);
        /// <summary>
        /// Returns a course record.
        /// </summary>
        /// <param name="id">Course's id</param>
        /// <returns>The course</returns>
        Course? GetCourse(int id);
        /// <summary>
        /// Returns all records.
        /// </summary>
        /// <returns>All Courses</returns>
        List<Course> GetAllCourses();
        /// <summary>
        /// Returns all teachers.
        /// </summary>
        /// <returns>All Teachers</returns>
        List<Teacher> GetAllTeachersForKey();
    }
}
