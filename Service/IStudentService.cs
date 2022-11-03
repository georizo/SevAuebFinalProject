using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentService
    {  
        /// <summary>
        /// Returns all students records.
        /// </summary>
        /// <returns>a list of student objects</returns>
        List<Student> GetAllStudents();
        /// <summary>
        /// Inserts a student record.
        /// </summary>
        /// <param name="dto">User's input that is converted from StudentDTO to Student type.</param>
        void InsertStudent(StudentDTO? dto);
        /// <summary>
        /// Updates a student record.
        /// </summary>
        /// <param name="dto">User's input that is converted from StudentDTO to Student type</param>
        void UpdateStudent(StudentDTO? dto);
        /// <summary>
        /// Deletes a student record.
        /// </summary>
        /// <param name="dto">User's input that is converted from StudentDTO to Student type</param>
        /// <returns></returns>
        Student? DeleteStudent(StudentDTO? dto);
        /// <summary>
        /// Returns a student record.
        /// </summary>
        /// <param name="id">student's id</param>
        /// <returns>a student object</returns>
        Student? GetStudent(int id);
    }
}
