using SevStudentsApp.DAO.DBUtil;
using SevStudentsApp.Models;
using System.Data.SqlClient;

namespace SevStudentsApp.DAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public void Insert(StudentCourse? studentCourse)
        {
            if (studentCourse == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "INSERT INTO STUDENTCOURSE " +
                    "(studentId, courseId) VALUES " +
                    "(@student_Id, @course_Id)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@student_Id", studentCourse.studentId);
                command.Parameters.AddWithValue("@course_Id", studentCourse.courseId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse? Delete(StudentCourse? studentCourse)
        {
            if (studentCourse == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return null;

                string sql = "DELETE FROM StudentCourse WHERE studentID = @student_id AND courseId = @course_id";


                using SqlCommand command = new(sql, conn);

                command.Parameters.AddWithValue("@student_id", studentCourse.studentId);
                command.Parameters.AddWithValue("@course_id", studentCourse.courseId);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? studentCourse : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentCourse = new List<StudentCourse>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM StudentCourse";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse studentCourse1 = new StudentCourse()
                    {
                        studentId = reader.GetInt32(0),
                        courseId = reader.GetInt32(1)
                    };

                    studentCourse.Add(studentCourse1);
                }

                return studentCourse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM COURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        description = reader.GetString(1),
                        teacherId = reader.GetInt32(2)
                    };

                    courses.Add(course);
                }

                return courses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    students.Add(student);
                }

                return students;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

    }
}
