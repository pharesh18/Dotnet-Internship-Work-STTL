using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
	public class StudentData
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
