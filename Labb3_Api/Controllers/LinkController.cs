using Labb3_Api.Application.Interfaces;
using Labb3_Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LinkController : ControllerBase
	{
		private readonly ILinkService _linkService;

		public LinkController(ILinkService linkService)
		{
			_linkService = linkService;
		}
		[HttpPost]
		public async Task<IActionResult> AddLink(AddNewLinkRequest link)
		{
			if (link == null)
			{
				return BadRequest("Link cannot be null.");
			}
			var updatedLink = await _linkService.AddNewLink(link);
			if (updatedLink == null)
			{
				return NotFound($"Error, invalid person Id or Interest Id");
			}
			return Ok(updatedLink);
		}
	}
}
