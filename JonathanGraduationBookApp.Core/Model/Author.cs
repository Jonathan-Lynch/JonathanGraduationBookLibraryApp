using System.Collections.Generic;

namespace JonathanGraduationBookApp.Core.Model
{
	public class Author
	{
		public int Id { get; set; }
		public string AuthorName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
