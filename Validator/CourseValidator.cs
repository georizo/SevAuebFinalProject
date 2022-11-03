using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class CourseValidator
    {
        private CourseValidator() { }

        public static string Validate(CourseDTO? dto)
        {
            if (dto is not null && dto.description is not null)
            {
                if ((dto.description.Length < 4))
                {
                    return "Subject description should not be less than four characters";
                }
                else
                {
                    return "";
                }


            }
            else
            {
                return "";
            }
        }
    }
}