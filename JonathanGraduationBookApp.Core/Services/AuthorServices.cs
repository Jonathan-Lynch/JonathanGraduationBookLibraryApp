using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JonathanGraduationBookApp.Core.Services
{
	public class AuthorServices : IAuthorServices
	{
		private readonly IAuthorRepository _authorRepo;
		public AuthorServices(IAuthorRepository authorRepo)
		{
			_authorRepo = authorRepo;
		}

		public Author Add(Author newAuthor)
		{
			return _authorRepo.Add(newAuthor);
		}

		public Author Get(int id)
		{
			return _authorRepo.Get(id);
		}

		public IEnumerable<Author> GetAll()
		{
			return _authorRepo.GetAll();
		}

		public void Remove(int id)
		{
			var author = _authorRepo.Get(id);
			_authorRepo.Remove(author);
		}

		public Author Update(Author updateAuthor)
		{
			return _authorRepo.Update(updateAuthor);
		}
	}
}
