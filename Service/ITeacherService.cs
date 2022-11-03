using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ITeacherService
    {
        /// <summary>
        /// Returns a list of all teachers.
        /// </summary>
        /// <returns>All Teachers</returns>
        List<Teacher> GetAllTeachers();
        /// <summary>
        /// Inserts a teacher record
        /// </summary>
        /// <param name="dto">User's input.TeacherDTO is converted in a Teacher type</param>
        void InsertTeacher(TeacherDTO? dto);
        /// <summary>
        /// Updates a teacher record.
        /// </summary>
        /// <param name="dto">User's input.TeacherDTO is converted in a Teacher type</param>
        void UpdateTeacher(TeacherDTO? dto);
        /// <summary>
        /// Deletes a teacher record.
        /// </summary>
        /// <param name="dto">User's input.TeacherDTO is converted in a Teacher type</param>
        /// <returns>The teacher deleted</returns>
        Teacher? DeleteTeacher(TeacherDTO? dto);
        /// <summary>
        /// Returns a teacher based on id given.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The teacher object</returns>
        Teacher? GetTeacher(int id);
    }
}
