using Labb3_Api.DTOs;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonRepository _personRepository;
		public PersonController(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}
		[HttpGet(Name = "GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var persons = await _personRepository.GetAllAsync();
			if(persons == null || !persons.Any())
			{
				return NotFound("No people found.");
			}
			return Ok(persons);
		}

		[HttpGet("{id}", Name ="GetById")]
		public async Task<IActionResult> GetById(int id)
		{
			var person = await _personRepository.GetByIdAsync(id);
			if (person == null)
			{
				return NotFound($"Person with ID {id} not found.");
			}
			return Ok(person);
		}


		[HttpGet("{id}/links", Name = "GetAllPersonLinks")]
		public async Task<IActionResult> GetAllLinks(int id)
		{
			var links = await _personRepository.GetAllLinksAsync(id);
			if (links == null || !links.Any())
			{
				return NotFound($"No links found for person with ID {id}.");
			}
			return Ok(links);
		}

		[HttpPost("{personId}/interests/{interestId}", Name = "AddPersonInterest")]
		public async Task<IActionResult> AddInterest(int personId, int interestId)
		{
			var person = await _personRepository.AddInterest(personId, interestId);
			if (person == null)
			{
				return NotFound($"Person with ID {personId} or Interest with ID {interestId} not found.");
			}
			return CreatedAtAction(nameof(AddInterest), new { id = person.Id });
		}
	}
}
