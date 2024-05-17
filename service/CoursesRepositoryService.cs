using Student_Information_System.model;
using Student_Information_System.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.service
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void AssignTeacher(int courseId)
        {
            Console.WriteLine("Enter Teacher ID:");
            int teacherId = Convert.ToInt32(Console.ReadLine());

            Teacher teacher = new TeacherRepository().DisplayTeacherInfo(teacherId);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            _courseRepository.AssignTeacher(courseId, teacher);
            Console.WriteLine("Teacher assigned successfully.");
        }

        public void UpdateCourseInfo(int courseId)
        {
            Console.WriteLine("Enter Course Name:");
            string courseName = Console.ReadLine();
            Console.WriteLine("Enter Credits:");
            int courseCredits = Convert.ToInt32(Console.ReadLine());
           

            _courseRepository.UpdateCourseInfo(courseId, courseName, courseCredits);
            Console.WriteLine("Course information updated successfully.");
        }

        public void DisplayCourseInfo(int courseId)
        {
            Course course = _courseRepository.DisplayCourseInfo(courseId);

            if (course != null)
            {
                Console.WriteLine($"Course ID: {course.CourseID}");
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine($"Instructor: {course.Instructor}");
                Console.WriteLine($"Credits: {course.Credits}");

                Teacher teacher = _courseRepository.GetTeacher(courseId);
                if (teacher != null)
                {
                    Console.WriteLine($"Assigned Teacher: {teacher.FirstName} {teacher.LastName}");
                }
                else
                {
                    Console.WriteLine("No teacher assigned.");
                }
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        public void DisplayEnrollments(int courseId)
        {
            List<Enrollment> enrollments = _courseRepository.GetEnrollments(courseId);

            if (enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments found.");
                return;
            }

            foreach (var enrollment in enrollments)
            {
                Student student = new StudentRepository().DisplayStudentInfo(enrollment.StudentID);
                if (student != null)
                {
                    Console.WriteLine($"Enrollment ID: {enrollment.EnrollmentID}, Student: {student.FirstName} {student.LastName}");
                }
                else
                {
                    Console.WriteLine($"Enrollment ID: {enrollment.EnrollmentID}, Student ID: {enrollment.StudentID}");
                }
            }
        }
    }
}