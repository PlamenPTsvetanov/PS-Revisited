namespace StudentInfoSystem;
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentData 
{
    private static List<Student> _testStudents;
    public static List<Student> TestStudents 
    {
        get 
        {
            _testStudents = new List<Student>();

            Student newStudent = new Student();
            newStudent.Name = "Plamen";
            newStudent.MiddleName = "Plamenov";
            newStudent.FamilyName = "Tsvetanov";
            newStudent.Faculty = "Faculty of Computer Science";
            newStudent.Specialty = "Computer and Software Engineering";
            newStudent.EducationLevel = "Bachelors";
            newStudent.Status = "Active";
            newStudent._facultyNumber = "121220013";
            newStudent.Course = "3";
            newStudent.FacultyGroup = "9";
            newStudent.LocalizedGroup = "43";
            newStudent._creationDate = DateTime.Now;
            newStudent._validTo = DateTime.MaxValue;
            _testStudents.Add(newStudent);
            return _testStudents; 
        }
        private set 
        {
            TestStudents = _testStudents;
        }
    }

    public void copyTestStudents()
    {
        StudentInfoContext context = new StudentInfoContext();
        
        foreach (Student student in TestStudents)
        {
            context.Students.Add(student);
        }

        context.SaveChanges();
    }


    private static List<Student> GetRegions()
    {
        StudentInfoContext context = new StudentInfoContext();
        List<Student> students = context.Students.ToList();
        return students;
    }

    public Student isThereStudent(String facNum)
    {
        StudentInfoContext context = new StudentInfoContext();
        Student result = 
            (from st in context.Students where st._facultyNumber == facNum select st).First();
        return result;
    }

    public Student isUserPassCorrect(String facNum, String password)
    {
        StudentInfoContext context = new StudentInfoContext();
        Student result =
            (from st in context.Students where st._facultyNumber == facNum & st._password == password select st).First();
        return result;
    }
}
