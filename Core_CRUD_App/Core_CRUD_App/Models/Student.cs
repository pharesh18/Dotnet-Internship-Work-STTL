using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core_CRUD_App.Models;

public partial class Student
{
    public int Id { get; set; }
    [Required]
    public string Fname { get; set; } = null!;
	[Required]
	public string Lname { get; set; } = null!;
	[Required]
	public int Age { get; set; }
	[Required]
	public string Email { get; set; } = null!;
	[Required]
	public string Password { get; set; } = null!;
	[Required]
	public string Gender { get; set; } = null!;
}
