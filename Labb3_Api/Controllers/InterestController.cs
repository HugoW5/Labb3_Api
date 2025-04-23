using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InterestController : ControllerBase
	{
		private readonly IInterestRepository _interestRepository;
		public InterestController(IInterestRepository interestRepository)
		{
			_interestRepository = interestRepository;
		}
		[HttpGet(Name = "GetAllInterests")]
		public async Task<IActionResult> GetAllInterests()
		{
			var interests = await _interestRepository.GetAllAsync();
			if (interests == null || !interests.Any())
			{
				return NotFound("No interests found.");
			}
			return Ok(interests);
		}
		[HttpPost(Name = "AddInterest")]
		public async Task<IActionResult> AddInterest(InterestDTO interest)
		{
			if (interest == null)
			{
				return BadRequest("Interest cannot be null.");
			}
			var addedInterest = await _interestRepository.AddInterest(interest);
			if(addedInterest == null)
			{
				return BadRequest("Failed to add interest.");
			}
			return CreatedAtAction(nameof(GetAllInterests), new { id = addedInterest.Id }, addedInterest);
		}
		[HttpGet("{id}/links", Name = "GetAllInterestLinks")]
		public async Task<IActionResult> GetAllLinks(int id)
		{
			var links = await _interestRepository.GetAllLinksAsync(id);
			if (links == null || !links.Any())
			{
				return NotFound($"No links found for interest with ID {id}.");
			}
			return Ok(links);
		}
	}
}
