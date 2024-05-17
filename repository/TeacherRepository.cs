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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _cmd;

        public TeacherRepository()
        {
            _sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            _cmd = new SqlCommand();
            _cmd.Connection = _sqlConnection;
        }

        public void UpdateTeacherInfo(int teacherId, string name, string email, string expertise)
        {
            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "UPDATE Teacher SET first_name = @FirstName, last_name = @LastName, email = @Email, expertise = @Expertise WHERE teacher_id = @TeacherId";
                _cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                _cmd.Parameters.AddWithValue("@FirstName", name.Split(' ')[0]);
                _cmd.Parameters.AddWithValue("@LastName", name.Split(' ')[1]);
                _cmd.Parameters.AddWithValue("@Email", email);
                _cmd.Parameters.AddWithValue("@Expertise", expertise);

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

        public Teacher DisplayTeacherInfo(int teacherId)
        {
            return null;
        }

        public List<Course> GetAssignedCourses(int teacherId)
        {
            List<Course> assignedCourses = new List<Course>();

            try
            {
                _sqlConnection.Open();
                _cmd.CommandText = "SELECT * FROM Courses WHERE teacher_id = @TeacherId";
                _cmd.Parameters.AddWithValue("@TeacherId", teacherId);

                SqlDataReader reader = _cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course(
                        reader.GetInt32(0),       // CourseID
                        reader.GetString(1),      // CourseName
                        reader.GetInt32(2),       // Credits
                        reader.GetInt32(3)        // TeacherID
                    );
                    assignedCourses.Add(course);
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

            return assignedCourses;
        }

        private List<string> GetExpertiseList(string expertiseString)
        {
            // Split the expertiseString by comma to get individual areas of expertise
            string[] expertiseArray = expertiseString.Split(',');
            return new List<string>(expertiseArray);
        }
    }
}

