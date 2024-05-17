using Student_Information_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.repository
{
    public interface IEnrollmentRepository
    {

        Student GetStudent(int enrollmentId);
        Course GetCourse(int enrollmentId);
    }

}

