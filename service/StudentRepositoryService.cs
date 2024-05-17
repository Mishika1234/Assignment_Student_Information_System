using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.model;
using Student_Information_System.repository;

namespace Student_Information_System.service
{
   public class StudentRepositoryService
    {
        readonly IStudentRepository _studentRepository;

        public StudentRepositoryService(IStudentRepository studentRepository)
        {
             _studentRepository = new StudentRepository();
        }

        public void AddStudent()
        {
            Console.WriteLine("Enter student details:");
            Console.Write("Student ID: ");
            int studentID = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date of Birth (YYYY-MM-DD): ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            // Create a new Student object with the entered details
            Student student = new Student(studentID, firstName, lastName, dateOfBirth, email, phoneNumber);

            // Add the student to the repository
            int result = _studentRepository.AddStudent(student);

            // Check the result of the operation
            if (result > 0)
            {
                Console.WriteLine("Student added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add student.");
            }

        }

        public void GetStudents()
        {
            Console.WriteLine("Fetching all students...");
            List<Student> students = _studentRepository.GetStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("Student List:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentID}, Name: {student.FirstName} {student.LastName}, DOB: {student.DateOfBirth.ToShortDateString()}, Email: {student.Email}, Phone: {student.PhoneNumber}");
            }
        }
        public void DisplayStudentInfo()
        {
            Console.WriteLine("Enter the Student ID to display: ");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Student student = _studentRepository.DisplayStudentInfo(studentId);
            if (student != null)
            {
                Console.WriteLine("Student ID: " + student.StudentID);
                Console.WriteLine("First Name: " + student.FirstName);
                Console.WriteLine("Last Name: " + student.LastName);
                Console.WriteLine("Date of Birth: " + student.DateOfBirth.ToShortDateString());
                Console.WriteLine("Email: " + student.Email);
                Console.WriteLine("Phone Number: " + student.PhoneNumber);
            }
            else
            {
                Console.WriteLine("Student with ID " + studentId + " not found.");
            }
        }
        public int UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            return _studentRepository.UpdateStudentInfo(studentId, firstName, lastName, dateOfBirth, email, phoneNumber);
        }

        public void DeleteStudent()
        {
            Console.Write("Enter the Student ID to delete: ");
            int studentId;
            if (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.WriteLine("Invalid student ID. Please enter a valid number.");
                return;
            }

            // Call the repository method to delete the student
            _studentRepository.DeleteStudent(studentId);

            Console.WriteLine($"Student with ID {studentId} deleted successfully.");
        }

        public void EnrollInCourse()
        {
            Console.WriteLine("Enter student ID:");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter course ID:");
            int courseId = Convert.ToInt32(Console.ReadLine());

            _studentRepository.EnrollInCourse(studentId, courseId);
        }




    }

}
