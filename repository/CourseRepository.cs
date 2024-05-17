using Microsoft.Data.SqlClient;
using Student_Information_System.model;
using Student_Information_System.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _cmd;

        public CourseRepository()
        {
            _sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            _cmd = new SqlCommand();
            _cmd.Connection = _sqlConnection;
        }

        public void AssignTeacher(int courseId, Teacher teacher)
        {
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "UPDATE Courses SET teacher_id = @TeacherID WHERE course_id = @CourseID";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@CourseID", courseId);
                _cmd.Parameters.AddWithValue("@TeacherID", teacher.TeacherID);

                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void UpdateCourseInfo(int courseId, string courseName, int credits)
        {
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "UPDATE Courses SET course_name = @CourseName, credits = @Credits WHERE course_id = @CourseId";
                _cmd.Parameters.AddWithValue("@CourseId", courseId);
                _cmd.Parameters.AddWithValue("@CourseName", courseName);
                _cmd.Parameters.AddWithValue("@Credits", credits);

                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public Course DisplayCourseInfo(int courseId)
        {
            Course course = null;

            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT * FROM Courses WHERE course_id = @CourseID";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@CourseID", courseId);

                SqlDataReader reader = _cmd.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course(
                        reader.GetInt32(0),      // CourseID
                        reader.GetString(1),     // CourseName
                        reader.GetInt32(2),       // CourseCredits
                        reader.GetInt32(2)     // TeacherID
                       
                    );
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }

            return course;
        }

        public List<Enrollment> GetEnrollments(int courseId)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT * FROM Enrollments WHERE course_id = @CourseID";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@CourseID", courseId);

                SqlDataReader reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment(
                        reader.GetInt32(0),   // EnrollmentID
                        reader.GetInt32(1),   // StudentID
                        reader.GetInt32(2),   // CourseID
                        reader.GetDateTime(3) // EnrollmentDate
                    );
                    enrollments.Add(enrollment);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }

            return enrollments;
        }

        public Teacher GetTeacher(int courseId)
        {
            Teacher teacher = null;

            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT teacher_id FROM Courses WHERE course_id = @CourseID";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@CourseID", courseId);

                object result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    int teacherId = Convert.ToInt32(result);
                    teacher = new TeacherRepository().DisplayTeacherInfo(teacherId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }

            return teacher;
        }
        public Course GetCourseById(int courseId)
        {
            Course course = null;

            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT * FROM Courses WHERE course_id = @CourseId";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@CourseId", courseId);

                SqlDataReader reader = _cmd.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course
                    (
                         reader.GetInt32(0),
                         reader.GetString(1),
                        reader.GetInt32(2),
                         reader.GetInt32(3));            
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }

            return course;
        }
    }
}
