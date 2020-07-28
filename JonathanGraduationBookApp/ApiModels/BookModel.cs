using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JonathanGraduationBookApp.ApiModels
{
	public class BookModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public int AuthorId { get; set; }
		public string Author { get; set; }
	}
}
