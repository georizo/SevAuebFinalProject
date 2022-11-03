using SevStudentsApp.Models;

namespace SevStudentsApp.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string? description { get; set; }

        public int teacherId { get; set; }

    }
}
