using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JonathanGraduationBookApp.Core.Services
{
	public interface IAuthorServices
	{// CRUDL - create (add), read (get), update, delete (remove), list

		//Create
		Author Add(Author newAuthor);

		//Read
		Author Get(int id);

		//Update
		Author Update(Author newAuthor);

		//Delete
		void Remove(int id);

		IEnumerable<Author> GetAll();
	}
}
