using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JonathanGraduationBookApp.Core.Services
{
	public class AuthorServices : IAuthorServices
	{
		private readonly IAuthorServices _authorServices;
		//public AuthorServices(IAuthorServices authorServices)
		//{
		//	_authorServices = authorServices;
		//}

		public Author Add(Author newAuthor)
		{
			return _authorServices.Add(newAuthor);
		}

		public Author Get(int id)
		{
			return _authorServices.Get(id);
		}

		public IEnumerable<Author> GetAll()
		{
			return _authorServices.GetAll();
		}

		public void Remove(int id)
		{
			_authorServices.Remove(id);
		}

		public Author Update(Author updateAuthor)
		{
			return _authorServices.Update(updateAuthor);
		}
	}
}
