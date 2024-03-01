using System.ComponentModel.DataAnnotations;

namespace ThreeTierArchitectureUI.Models
{
	public class StudentModel
	{
		public int Id { get; set; }
		[Required]
		public string Fname { get; set; }
		[Required]
		public string Lname { get; set; }
		[Required]
		public int Age { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Gender { get; set; }
	}
}
