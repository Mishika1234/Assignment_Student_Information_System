using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student_Information_System.model;
using Student_Information_System.repository;
using Student_Information_System.service;
using Student_Information_System.utility;

namespace Student_Information_System
{
    internal class Program
    {
        static void Main(string[] args)
        {


          
           
            IStudentRepository studentRepository = new StudentRepository();
            StudentRepositoryService studentService = new StudentRepositoryService(studentRepository);

            IPaymentRepository paymentRepository = new PaymentRepository();
            PaymentRepositoryService paymentService = new PaymentRepositoryService(paymentRepository);

            ITeacherRepository teacherRepository = new TeacherRepository();
            TeacherService teacherService = new TeacherService(teacherRepository);

            IEnrollmentRepository enrollmentRepository = new EnrollmentRepository();
            EnrollmentService enrollmentService = new EnrollmentService(enrollmentRepository);

            ICourseRepository courseRepository = new CourseRepository();
            CourseService courseService = new CourseService(courseRepository);


            while (true)
            {
                Console.WriteLine("\nStudent Information System\n");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Display Student Info by ID");
                Console.WriteLine("4. Update Student Information");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Enroll a student in a course");
                Console.WriteLine("7. Get Student from Payment ID");
                Console.WriteLine("8. Get Payment Amount");
                Console.WriteLine("9. Get Payment Date");
                Console.WriteLine("10.Update Teacher Info");
                Console.WriteLine("11. Display Teacher Info");
                Console.WriteLine("12. Get Assigned Courses by Teacher ID");
                Console.WriteLine("13. Get Student by Enrollment ID");
                Console.WriteLine("14. Get Course by Enrollment ID");
                Console.WriteLine("15. Assign Teacher to Course");
                Console.WriteLine("16. Update Course Information");
                Console.WriteLine("17. Display Course Information");
                Console.WriteLine("18. Display Enrollments for Course");
                Console.WriteLine("19. Exit");
                
                // Get user choice
                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    continue;
                }

                // Process user choice
                switch (choice)
                {
                    case 1:
                        studentService.AddStudent();
                        break;
                    case 2:
                        studentService.GetStudents();
                        break;
                    case 3:
                        studentService.DisplayStudentInfo();
                        break;
                    case 4:
                        // Update student info logic
                        Console.Write("Enter student ID to update: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter date of birth (YYYY-MM-DD): ");
                        DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();

                        int result = studentService.UpdateStudentInfo(studentId, firstName, lastName, dateOfBirth, email, phoneNumber);
                        if (result > 0)
                        {
                            Console.WriteLine("Student info updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update student info.");
                        }
                        break;
                    case 5:
                        studentService.DeleteStudent();
                        break;
                    case 6:
                        studentService.EnrollInCourse();
                        break;
                    case 7:
                        paymentService.GetStudent();
                        break;
                    case 8:
                        paymentService.GetPaymentAmount();
                        break;
                    case 9:
                        paymentService.GetPaymentDate();
                        break;
                    case 10:
                        teacherService.UpdateTeacherInfo();
                        break;
                    case 11:
                        teacherService.DisplayTeacherInfo();
                        break;
                    case 12:
                        teacherService.GetAssignedCourses();
                        break;
                    case 13:
                        enrollmentService.GetStudent();
                        break;
                    case 14:
                        enrollmentService.GetCourse();
                        break;

                    case 15:
                        Console.WriteLine("Enter Course ID:");
                        int courseId1 = Convert.ToInt32(Console.ReadLine());
                        courseService.AssignTeacher(courseId1);
                        break;
                    case 16:
                        Console.WriteLine("Enter Course ID:");
                        int courseId2 = Convert.ToInt32(Console.ReadLine());
                        courseService.UpdateCourseInfo(courseId2);
                        break;
                    case 17:
                        Console.WriteLine("Enter Course ID:");
                        int courseId3 = Convert.ToInt32(Console.ReadLine());
                        courseService.DisplayCourseInfo(courseId3);
                        break;
                    case 18:
                        Console.WriteLine("Enter Course ID:");
                        int courseId4 = Convert.ToInt32(Console.ReadLine());
                        courseService.DisplayEnrollments(courseId4);
                        break;

                    case 19:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        break;
                }
            
            }
        }
    }
}
    



    

