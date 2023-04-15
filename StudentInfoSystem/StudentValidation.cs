using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student getStudentDataByUser(User user)
        {

            if (user._facultyNumber.Equals(String.Empty))
            {
                Console.WriteLine("Faculty number cannot be empty!");
            }

            foreach (Student student in StudentData.TestStudents)
            {
                if (student._facultyNumber.Equals(user._facultyNumber))
                {
                    return student;
                }
            }
            Console.WriteLine("No student with such faculty number found!");
            return null;
        }
        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            IEnumerable<Student> queryStudents = context.Students;

            int count = queryStudents.Count();

            return count == 0 ? true : false;
        }

        
    }
}
