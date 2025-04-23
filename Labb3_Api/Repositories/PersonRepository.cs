using Labb3_Api.Models;
using Labb3_Api.Data;
using Labb3_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Labb3_Api.DTOs;

namespace Labb3_Api.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly AppDbContext _context;
		public PersonRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Person?> AddInterest(int personId, int interestId)
		{
			Person? person = await _context.Persons.FindAsync(personId);
			if (person == null)
			{
				return null;
			}
			Interest? interest = _context.Interests.FirstOrDefault(i => i.Id == interestId);
			if (interest == null)
			{
				return null;
			}
			person.Interests.Add(interest);
			_context.SaveChanges();
			return person;
		}

		public async Task<IEnumerable<Person>> GetAllAsync()
		{
			return await _context.Persons.ToListAsync();
		}

		public async Task<IEnumerable<LinkDTO>> GetAllLinksAsync(int id)
		{
			return await _context.Links.Where(l => l.Person.Id == id)
				.Select(l=> new LinkDTO
				{
					Url = l.Url
				}).ToListAsync();
		}

		public async Task<PersonDTO?> GetByIdAsync(int id)
		{
			return await _context.Persons.Where(p => p.Id == id)
				.Select(p => new PersonDTO
				{
					Id = p.Id,
					FirstName = p.FirstName,
					LastName = p.LastName,
					Email = p.Email,
					PhoneNumber = p.PhoneNumber,
					Links = p.Links.Select(l => new LinkDTO
					{
						Url = l.Url
					}).ToList(),
					Interests = p.Interests.Select(i => new InterestDTO
					{
						Id = i.Id,
						Title = i.Title,
						Description = i.Description
					}).ToList()
				}).FirstOrDefaultAsync();
		}
	}
}
