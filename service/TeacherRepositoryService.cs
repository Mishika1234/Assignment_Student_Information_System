using Student_Information_System.model;
using Student_Information_System.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.service
{
    public class TeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void UpdateTeacherInfo()
        {
            Console.WriteLine("Enter teacher ID:");
            int teacherId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new full name (FirstName LastName):");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter new expertise (comma separated):");
            string expertise = Console.ReadLine();

            _teacherRepository.UpdateTeacherInfo(teacherId, name, email, expertise);

            Console.WriteLine("Teacher information updated successfully!");
        }

        public void DisplayTeacherInfo()
        {
            Console.WriteLine("Enter teacher ID:");
            int teacherId = Convert.ToInt32(Console.ReadLine());

            Teacher teacher = _teacherRepository.DisplayTeacherInfo(teacherId);

            if (teacher != null)
            {
                Console.WriteLine($"Teacher ID: {teacher.TeacherID}");
                Console.WriteLine($"Name: {teacher.FirstName} {teacher.LastName}");
                Console.WriteLine($"Email: {teacher.Email}");
                Console.WriteLine($"Expertise: {teacher.Expertise}");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }

        public void GetAssignedCourses()
        {
            Console.WriteLine("Enter teacher ID:");
            int teacherId = Convert.ToInt32(Console.ReadLine());

            List<Course> courses = _teacherRepository.GetAssignedCourses(teacherId);

            if (courses.Count > 0)
            {
                Console.WriteLine("Assigned Courses:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Course ID: {course.CourseID}, Course Name: {course.CourseName}, Credits: {course.Credits}");
                }
            }
            else
            {
                Console.WriteLine("No courses assigned to this teacher.");
            }
        }
    }
}
