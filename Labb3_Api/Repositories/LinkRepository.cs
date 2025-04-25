using Labb3_Api.Application.Interfaces;
using Labb3_Api.Data;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;

namespace Labb3_Api.Repositories
{
	public class LinkRepository : ILinkRepository
	{
		private readonly AppDbContext _context;

		public LinkRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Link> AddLink(Link link)
		{
			await _context.Links.AddAsync(link);
			await _context.SaveChangesAsync();

			return _context.Links.ToList()[^1];
		}
	}
}
