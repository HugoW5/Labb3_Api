using Labb3_Api.Data;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb3_Api.Repositories
{
	public class InterestRepository : IInterestRepository
	{
		private readonly AppDbContext _context;
		public InterestRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Interest?> AddInterest(InterestDTO interest)
		{
			Interest newInterest = new Interest
			{
				Title = interest.Title,
				Description = interest.Description,
				Links = new List<Link>()
			};
			await _context.Interests.AddAsync(newInterest);
			_context.SaveChanges();
			return _context.Interests.ToList()[^1];
		}

		public async Task<IEnumerable<Interest>> GetAllAsync()
		{
			return await _context.Interests.ToListAsync();
		}

		public async Task<IEnumerable<LinkDTO>> GetAllLinksAsync(int id)
		{
			return await _context.Links.Where(l => l.Interest.Id == id)
				.Select(l => new LinkDTO
				{
					Url = l.Url
				}).ToListAsync();
		}
	}
}
