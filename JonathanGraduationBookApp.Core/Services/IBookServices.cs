using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace JonathanGraduationBookApp.Core.Services
{
	public interface IBookServices
	{ // CRUDL - create (add), read (get), update, delete (remove), list

		//Create
		Book Add(Book newBook);

		//Read
		Book Get(int id);

		//Update
		Book Update(Book newBook);

		//Delete
		void Remove(int id);

		//List
		IEnumerable<Book> GetAll();
		IEnumerable<Book> GetBooksForAuthor(int authorId);
	}
}
