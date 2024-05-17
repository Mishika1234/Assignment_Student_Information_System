using Student_Information_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.model;

namespace Student_Information_System.repository
{
    public interface ICourseRepository
    {
        void AssignTeacher(int courseId, Teacher teacher);
        void UpdateCourseInfo(int courseId, string courseName, int credits);
        Course DisplayCourseInfo(int courseId);
        List<Enrollment> GetEnrollments(int courseId);
        Teacher GetTeacher(int courseId);
        Course GetCourseById(int courseId);
    }
}
