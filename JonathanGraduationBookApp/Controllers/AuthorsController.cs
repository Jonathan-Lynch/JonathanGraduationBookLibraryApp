﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JonathanGraduationBookApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using JonathanGraduationBookApp.ApiModels;
using JonathanGraduationBookApp.Core.Model;

namespace JonathanGraduationBookApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorServices _authorServices;

		public AuthorsController(IAuthorServices authorServices)
		{
			_authorServices = authorServices;
		}

		//get api/authors
		[HttpGet]
		public IActionResult Get()
		{
			var authorModel = _authorServices.GetAll().ToApiModels();
			return Ok(authorModel);
		}

		//get api/authors/:id
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var author = _authorServices.Get(id).ToApiModel();
			if (author == null) return NotFound();
			return Ok(author);
		}

		//Post api/authors/:id
		[HttpPost]
		public IActionResult Post([FromBody] AuthorModel newAuthor)
		{
			try
			{
				_authorServices.Add(newAuthor.ToDomainModel());
			}
			catch (System.Exception ex)
			{
				ModelState.AddModelError("addAuthor", ex.GetBaseException().Message);
			}
			return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
		}

		//put api/books/:id
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Author updatedAuthor)
		{
			try
			{
				return Ok(_authorServices.Update(updatedAuthor).ToApiModel());
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("UpdateAuthor", ex.Message);
				return BadRequest(ModelState);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			//var author = _authorServices.Get(id);
			//if (author == null) return NotFound();
			_authorServices.Remove(id);
			return NoContent();
		}
	}
}
