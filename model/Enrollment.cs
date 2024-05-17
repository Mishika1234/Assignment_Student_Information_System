using Student_Information_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.model
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Student Student { get; set; } // Relationship: One enrollment belongs to one student
        public Course Course { get; set; } // Relationship: One enrollment belongs to one course

        public Enrollment(int enrollmentID, int studentID, int courseID, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentID;
            StudentID = studentID;
            CourseID = courseID;
            EnrollmentDate = enrollmentDate;
        }
    }
}


