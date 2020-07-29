using System;
using System.Collections.Generic;
using System.Text;
using JonathanGraduationBookApp.Core.Model;

namespace JonathanGraduationBookApp.Core.Services
{
	public interface IBookRepository
	{
		Book Add(Book book);
		Book Update(Book book);
		Book Get(int id);
		IEnumerable<Book> GetAll();
		IEnumerable<Book> GetBooksForAuthor(int authorId);
		void Remove(int id);
	}
}
