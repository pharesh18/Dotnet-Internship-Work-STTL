using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

	public static explicit operator Student(List<Student> v)
	{
		throw new NotImplementedException();
	}
}
