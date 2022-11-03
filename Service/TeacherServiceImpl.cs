using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public class TeacherServiceImpl : ITeacherService
    {
        private readonly ITeacherDAO dao;

        public TeacherServiceImpl(ITeacherDAO dao)
        {
            this.dao = dao;
        }



        public Teacher? DeleteTeacher(TeacherDTO? dto)
        {

            if (dto is null) return null;

            try
            {
                Teacher? Teacher = Convert(dto);
                return dao.Delete(Teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return dao.GetAll();

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
            }
        }

        public Teacher? GetTeacher(int id)
        {
            try
            {
                return dao.GetTeacher(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertTeacher(TeacherDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Teacher? Teacher = Convert(dto);
                dao.Insert(Teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateTeacher(TeacherDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Teacher? Teacher = Convert(dto);
                dao.Update(Teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Teacher? Convert(TeacherDTO dto)
        {
            if (dto == null) return null;

            return new Teacher()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
