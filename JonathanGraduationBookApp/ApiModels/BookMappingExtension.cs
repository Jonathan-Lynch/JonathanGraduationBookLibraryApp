using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonathanGraduationBookApp.ApiModels
{
	public static class BookMappingExtension
	{
		public static BookModel ToApiModel(this Book book)
		{
			return new BookModel
			{
				Id = book.Id,
				Title = book.Title,
				Genre = book.Genre,
				AuthorId = book.AuthorId,

				Author = book.Author != null
					? book.Author.LastName + ", " + book.Author.FirstName
					: null
			};
		}

		public static Book ToDomainModel(this BookModel bookModel)
		{
			return new Book
			{
				Id = bookModel.Id,
				Title = bookModel.Title,
				Genre = bookModel.Genre,
				AuthorId = bookModel.AuthorId,
			};
		}

		public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> authors)
		{
			return authors.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModel> authorModels)
		{
			return authorModels.Select(a => a.ToDomainModel());
		}
	}
}
