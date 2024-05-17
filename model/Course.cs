using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.model
{
    public class Course
    {
        
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public int TeacherID { get; set; }
        public string Instructor { get; set; }
     

        public Course(int courseID, string courseName,int courseCredits, int teacherID)
        {
            CourseID = courseID;
            Credits = courseCredits;
            CourseName = courseName;
            TeacherID = teacherID;
   
        }     
    }
    
}

