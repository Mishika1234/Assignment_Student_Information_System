using Student_Information_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.repository
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student DisplayStudentInfo(int studentId);
        int AddStudent(Student student);
        int UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);
        void DeleteStudent(int studentId);
        void EnrollInCourse(int studentId, int courseId);
        //void MakePayment(int studentId, decimal amount, DateTime paymentDate);
       // List<Course> GetEnrolledCourses(int studentId);
       // List<Payment> GetPaymentHistory(int studentId);
    }
}
