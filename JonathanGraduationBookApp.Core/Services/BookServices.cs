using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
namespace JonathanGraduationBookApp.Core.Services
{
	public class BookServices : IBookServices
	{
		private readonly IBookRepository _bookRepository;

		public BookServices(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public Book Add(Book newBook)
		{
			return _bookRepository.Add(newBook);
		}

		public Book Get(int id)
		{
			return _bookRepository.Get(id);
		}

		public IEnumerable<Book> GetAll()
		{
			return _bookRepository.GetAll();
		}

		public IEnumerable<Book> GetBooksForAuthor(int id)
		{
			return _bookRepository.GetAll();
		}

		public void Remove(int id)
		{
			_bookRepository.Remove(id);
		}

		public Book Update(Book updateBook)
		{
			return _bookRepository.Update(updateBook);
		}
	}
}
