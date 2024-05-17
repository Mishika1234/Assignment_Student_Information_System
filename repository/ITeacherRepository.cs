using Student_Information_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.repository
{
    public interface ITeacherRepository
    {
        void UpdateTeacherInfo(int teacherId, string name, string email, string expertise);
        Teacher DisplayTeacherInfo(int teacherId);
        List<Course> GetAssignedCourses(int teacherId);
    }
}
