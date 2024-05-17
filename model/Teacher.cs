using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.model;

namespace Student_Information_System.model
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Expertise { get; set; }

        public Teacher(int teacherID, string firstName, string lastName, string email, List<string> expertise)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Expertise = expertise;
        }
        public void AddCourse(Course course)
        {
          //  AssignedCourses.Add(course);
        }

      /*  public List<Course> GetAssignedCourses()
        {
          //  return AssignedCourses;
        }*/
    }
}
