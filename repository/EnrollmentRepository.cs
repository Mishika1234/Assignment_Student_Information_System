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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _cmd;

        public EnrollmentRepository()
        {
            _sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            _cmd = new SqlCommand();
            _cmd.Connection = _sqlConnection;
        }

        public Student GetStudent(int enrollmentId)
        {
            Student student = null;
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT student_id FROM Enrollments WHERE enrollment_id = @EnrollmentId";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);

                object result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    int studentId = Convert.ToInt32(result);
                    student = new StudentRepository().DisplayStudentInfo(studentId);
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
            return student;
        }

      public Course GetCourse(int enrollmentId)
        {
            Course course = null;
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT course_id FROM Enrollments WHERE enrollment_id = @EnrollmentId";
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);

                object result = _cmd.ExecuteScalar();
                if (result != null)
                {
                    int courseId = Convert.ToInt32(result);
                    course = new CourseRepository().GetCourseById(courseId);
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
            return course;
        }
    }
}
