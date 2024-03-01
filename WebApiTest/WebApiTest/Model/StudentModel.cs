namespace WebApiTest.Model
{
	public class StudentModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public int Age { get; set; }
		public string Gender { get; set; } = string.Empty;

		public StudentModel(int id, string fname, string lname, string email, int age, string gender) {
			Id = id;
			FirstName = fname;
			LastName = lname;
			Email = email;
			Age = age;
			Gender = gender;
		}
	}
}
