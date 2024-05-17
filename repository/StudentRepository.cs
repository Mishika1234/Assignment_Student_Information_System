using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.utility;
using Student_Information_System.model;

namespace Student_Information_System.repository
{
    public class StudentRepository : IStudentRepository
    {
        /*SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        //constructor
        public StudentRepository()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-SIGP43GI;Database=SISDB;Trusted_Connection=True; Encrypt = false");
             sqlConnection=new SqlConnection(DbConnUtil.GetConnectionString());
             cmd = new SqlCommand();
        }

        public int AddStudent()
        { 
          
        }*/
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand cmd;

       
        public StudentRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }
       
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                sqlConnection.Open();
                cmd.CommandText = "SELECT * FROM Students";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student(
                        reader.GetInt32(0), // StudentID
                        reader.GetString(1), // FirstName
                        reader.GetString(2), // LastName
                        reader.GetDateTime(3), // DateOfBirth
                        reader.GetString(4), // Email
                        reader.GetString(5) // PhoneNumber
                    ));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return students;
        }

        public Student DisplayStudentInfo(int studentId)
        {
            Student student = null;
            try
            {
                sqlConnection.Open();
                cmd.CommandText = "SELECT student_id, first_name, last_name, date_of_birth, email, phone_number FROM Students WHERE student_id = @StudentId";
                cmd.Parameters.Clear(); // Clear parameters before adding new ones
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student(
                        Convert.ToInt32(reader["student_id"]),
                        reader["first_name"].ToString(),
                        reader["last_name"].ToString(),
                        Convert.ToDateTime(reader["date_of_birth"]),
                        reader["email"].ToString(),
                        reader["phone_number"].ToString()
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
                sqlConnection.Close();
            }
            return student;
        }


        public int AddStudent(Student student)
        {
            int rowsAffected = 0;

            try
            {
                
                sqlConnection.Open();

               
                string query = @"INSERT INTO Students (first_name, last_name, date_of_birth, email, phone_number)
                         VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @PhoneNumber);
                         SELECT SCOPE_IDENTITY();";

                cmd.CommandText = query;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);

               
                object result = cmd.ExecuteScalar();

                
                if (result != null && int.TryParse(result.ToString(), out int studentId))
                {
                    
                    student.StudentID = studentId;
                    rowsAffected = 1; // Indicates success
                }
                else
                {
                    
                    rowsAffected = 0; // Indicates failure
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error adding student: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                sqlConnection.Close();
            }

            return rowsAffected; // Return the number of rows affected (success/failure)
        }


        public int UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            int rowsAffected = 0;
            try
            {
                sqlConnection.Open();
                cmd.CommandText = "UPDATE Students SET first_name = @FirstName, last_name = @LastName, date_of_birth = @DateOfBirth, email = @Email, phone_number = @PhoneNumber WHERE student_id = @StudentId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return rowsAffected;
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                sqlConnection.Open();
                cmd.CommandText = "DELETE FROM Students WHERE student_id = @StudentId";
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting student: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

             void EnrollInCourse(int studentId, int courseId)
            {
                try
                {
                    sqlConnection.Open();

                    // Create a SqlCommand to insert a new enrollment record
                    SqlCommand cmd = new SqlCommand("INSERT INTO Enrollments (student_id, course_id, enrollment_date) VALUES (@StudentId, @CourseId, GETDATE())", sqlConnection);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Student enrolled in the course successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to enroll student in course: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

        }

        void IStudentRepository.EnrollInCourse(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }
    }

}

