using JonathanGraduationBookApp.Core.Model;
using JonathanGraduationBookApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JonathanGraduationBookApp.Infrastructure.Data
{
	public class AuthorRepository : IAuthorRepository
	{

		private readonly AppDbContext _appDbContext;

		public AuthorRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public Author Add(Author author)
		{
			_appDbContext.Authors.Add(author);
			_appDbContext.SaveChanges();
			return author;
		}

		public Author Get(int id)
		{
			return _appDbContext.Authors
				.Include(a => a.AuthorName)
				.SingleOrDefault(a => a.Id == id);
		}

		public IEnumerable<Author> GetAll()
		{
			return _appDbContext.Authors.Include(a => a.AuthorName);
		}

		public void Remove(int id)
		{
			var currentAuthor = _appDbContext.Authors.Include(a => a.Id == id);
			if (currentAuthor == null)
			{
				_appDbContext.Authors.Remove((Author)currentAuthor);
				_appDbContext.SaveChanges();
			}
		}

		public Author Update(Author updatedAuthor)
		{
			var currentAuthor = _appDbContext.Authors.Find(updatedAuthor.Id);
			if (currentAuthor == null) return null;
			_appDbContext.Entry(currentAuthor)
				.CurrentValues
				.SetValues(updatedAuthor);
			_appDbContext.Authors.Update(updatedAuthor);
			_appDbContext.SaveChanges();
			return currentAuthor;
		}
	}
}
