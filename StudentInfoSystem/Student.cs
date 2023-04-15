namespace StudentInfoSystem;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using UserLogin;

[Table("Students")]
public class Student : User
{
    public string Name
    {
        get; set;
    }

    public string? MiddleName
    {
        get; set;
    }

    public string FamilyName
    {
        get; set;
    }

    public string Faculty
    {
        get; set;
    }

    public string Specialty
    {
        get; set;
    }

    public string EducationLevel
    {
        get; set;
    }

    public string Status
    {
        get; set;
    }

    public string Course
    {
        get; set;
    }

    public string FacultyGroup
    {
        get; set;
    }

    public string LocalizedGroup
    {
        get; set;
    }

    public byte[] Image
    {
        get; set;
    }
}