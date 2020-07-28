using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JonathanGraduationBookApp.Core.Services
{
	public interface IAuthorRepository
	{
		Author Add(Author author);
		Author Get(int id);
		IEnumerable<Author> GetAll();
		Author Update(Author author);
		void Remove(int id);
	}
}
