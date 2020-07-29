using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JonathanGraduationBookApp.ApiModels;
using JonathanGraduationBookApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace JonathanGraduationBookApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBookServices _bookServices;

		public BooksController(IBookServices bookServices)
		{
			_bookServices = bookServices;
		}

		// get api/books
		[HttpGet]
		public IActionResult Get()
		{
			var bookModels = _bookServices.GetAll().ToApiModels();
			return Ok(bookModels);
		}


		//get api/books/:id
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var book = _bookServices.Get(id).ToApiModel();
			if (book == null) return NotFound();
			return Ok(book);
		}

		//Post api/books/:id
		[HttpPost]
		public IActionResult Post([FromBody] BookModel newBook)
		{
			try
			{
				_bookServices.Add(newBook.ToDomainModel());
			}
			catch (System.Exception ex)
			{
				ModelState.AddModelError("addBook", ex.GetBaseException().Message);
				return BadRequest(ModelState);
			}
			return CreatedAtAction("Get", new { Id = newBook.Id }, newBook);
		}

		//put api/books/:id
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] BookModel updatedBook)
		{
			var book = _bookServices.Update(updatedBook.ToDomainModel());
			if (book == null) return NotFound();
			return Ok(book.ToApiModel());
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var book = _bookServices.Get(id);
			if (book == null) return NotFound();
			_bookServices.Remove(id);
			return NoContent();
		}

		[HttpGet("/api/authors/{authorId}/books")]
		public IActionResult GetBooksForAuthor(int authorId)
		{
			var books = _bookServices.GetBooksForAuthor(authorId).ToApiModels();
			return Ok(books);
		}
	}
}
