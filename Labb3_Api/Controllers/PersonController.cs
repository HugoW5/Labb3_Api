using Labb3_Api.Application.Interfaces;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;
		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}
		[HttpGet(Name = "GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var persons = await _personService.GetAllPersonsAsync();
			if(persons == null || !persons.Any())
			{
				return NotFound("No people found.");
			}
			return Ok(persons);
		}

		[HttpGet("{id}", Name = "GetById")]
		public async Task<IActionResult> GetById(int id)
		{
			var person = await _personService.GetPersonByIdAsync(id);
			if (person == null)
			{
				return NotFound($"Person with ID {id} not found.");
			}
			return Ok(person);
		}


		[HttpGet("{id}/links", Name = "GetAllPersonLinks")]
		public async Task<IActionResult> GetAllLinks(int id)
		{
			var links = await _personService.GetAllLinksAsync(id);
			if (links == null || !links.Any())
			{
				return NotFound($"No links found for person with ID {id}.");
			}
			return Ok(links);
		}

		[HttpPost("{personId}/interests/{interestId}", Name = "AddPersonInterest")]
		public async Task<IActionResult> AddInterest(int personId, int interestId)
		{
			var person = await _personService.AddInterestAsync(personId, interestId);
			if (person == null)
			{
				return NotFound($"Person with ID {personId} or Interest with ID {interestId} not found.");
			}
			return CreatedAtAction(nameof(AddInterest), new { id = person.Id }, person);
		}
		[HttpPost(Name = "CreatePerson")]
		public async Task<IActionResult> CreatePerson(CreatePersonDTO person)
		{
			if (person == null)
			{
				return BadRequest("Person object is null.");
			}
			var createdPerson = await _personService.CreateNewPersonAsync(person);
			if (createdPerson == null)
			{
				return BadRequest("Failed to create person.");
			}
			return CreatedAtAction(nameof(GetById), new { id = createdPerson.Id }, createdPerson);
		}
	}
}
