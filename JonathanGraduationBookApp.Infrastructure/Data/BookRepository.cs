using JonathanGraduationBookApp.Core.Model;
using JonathanGraduationBookApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JonathanGraduationBookApp.Infrastructure.Data
{
	public class BookRepository : IBookRepository
	{

		private readonly AppDbContext _appDbContext;

		public BookRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public Book Add(Book book)
		{
			_appDbContext.Books.Add(book);
			_appDbContext.SaveChanges();
			return book;
		}

		public Book Get(int id)
		{
			return _appDbContext.Books
				.Include(t => t.Title)
				.SingleOrDefault(t => t.Id == id);
		}

		public IEnumerable<Book> GetAll()
		{
			return _appDbContext.Books
				.Include(a => a.Title);
		}

		public void Remove(int id)
		{
			var currentBook = _appDbContext.Books.SingleOrDefault(b => b.Id == id);
			if (currentBook != null)
			{
				_appDbContext.Books.Remove(currentBook);
				_appDbContext.SaveChanges();
			}
		}

		public Book Update(Book updatedBook)
		{
			var currentBook = _appDbContext.Books.Find(updatedBook.Id);  //grabs the book
			if (currentBook == null) return null; //checks to see if it exists or not
			_appDbContext.Entry(currentBook) //updates the current with the new
				.CurrentValues
				.SetValues(updatedBook);
			_appDbContext.Books.Update(currentBook);
			_appDbContext.SaveChanges();  //saves and returns the changes
			return currentBook;
		}
	}
}
