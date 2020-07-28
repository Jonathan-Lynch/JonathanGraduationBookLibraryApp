using JonathanGraduationBookApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonathanGraduationBookApp.ApiModels
{
	public static class AuthorMappingExtension
	{
		public static AuthorModel ToApiModel(this Author author)
		{
			return new AuthorModel
			{
				Id = author.Id,
				FirstName = author.FirstName,
				LastName = author.LastName,
			};
		}

		public static Author ToDomainModel(this AuthorModel authorModel)
		{
			return new Author
			{
				Id = authorModel.Id,
				FirstName = authorModel.FirstName,
				LastName = authorModel.LastName,
			};
		}

		public static IEnumerable<AuthorModel> ToApiModels(this IEnumerable<Author> authors)
		{
			return authors.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Author> ToDomainModel(this IEnumerable<AuthorModel> authorModels)
		{
			return authorModels.Select(a => a.ToDomainModel());
		}
	}
}
