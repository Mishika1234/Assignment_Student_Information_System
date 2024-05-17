using Student_Information_System.model;
using Student_Information_System.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.service
{
    public class EnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public void GetStudent()
        {
            Console.WriteLine("Enter Enrollment ID:");
            int enrollmentId = Convert.ToInt32(Console.ReadLine());

            Student student = _enrollmentRepository.GetStudent(enrollmentId);

            if (student != null)
            {
                Console.WriteLine($"Student ID: {student.StudentID}");
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Email: {student.Email}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void GetCourse()
        {
            Console.WriteLine("Enter Enrollment ID:");
            int enrollmentId = Convert.ToInt32(Console.ReadLine());

            Course course = _enrollmentRepository.GetCourse(enrollmentId);

            if (course != null)
            {
                Console.WriteLine($"Course ID: {course.CourseID}");
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine($"Credits: {course.Credits}");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
    }
}
