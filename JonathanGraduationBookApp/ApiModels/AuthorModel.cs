﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonathanGraduationBookApp.ApiModels
{
	public class AuthorModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public ICollection<BookModel> Books { get; set; }
	}
}
