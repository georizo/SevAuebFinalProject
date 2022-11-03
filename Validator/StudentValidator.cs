using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class StudentValidator
    {
        // No instances of this class should be available
        private StudentValidator() { }

        public static string Validate(StudentDTO? dto)
        {
            if ((dto!.Firstname!.Length < 4) ||
                (dto!.Lastname!.Length < 4))
            {
                return "Firstname or Lastname should not be less than three chars";
            }

            return "";
        }
    }
}
