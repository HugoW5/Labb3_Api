using Labb3_Api.Data;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Labb3_Api.Repositories
{
	public class InterestRepository : IInterestRepository
	{
		private readonly AppDbContext _context;
		public InterestRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Interest?> AddInterest(Interest interest)
		{
			await _context.Interests.AddAsync(interest);
			await _context.SaveChangesAsync();
			return _context.Interests.ToList()[^1];
		}

		public async Task<IEnumerable<Interest>> GetAllAsync()
		{
			return await _context.Interests.ToListAsync();
		}

		public async Task<IEnumerable<Link>> GetAllLinksAsync(int id)
		{
			return await _context.Links.Where(l => l.Interest.Id == id).ToListAsync();
		}

		public async Task<Interest?> GetInterestById(int id)
		{
			return await _context.Interests.FindAsync(id);
		}
	}
}
