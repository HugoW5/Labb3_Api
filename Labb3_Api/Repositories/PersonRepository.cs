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

		public async Task<Person?> AddInterest(Person person, Interest interest)
		{
			person.Interests.Add(interest);
			await _context.SaveChangesAsync();
			return person;
		}

		public async Task<Person> CreateNewPerson(Person person)
		{
			_context.Persons.Add(person);
			await _context.SaveChangesAsync();
			return _context.Persons.ToList()[^1];
		}

		public async Task<IEnumerable<Person>> GetAllAsync()
		{
			return await _context.Persons.ToListAsync();
		}

		public async Task<IEnumerable<Interest>> GetAllInterestsAsync(int id)
		{
			return await _context.Interests.Where(i => i.People.Any(p => p.Id == id)).ToListAsync();
		}

		public async Task<IEnumerable<Link?>> GetAllLinksAsync(int id)
		{
			return await _context.Links.Where(l => l.Person.Id == id).ToListAsync();
		}

		public async Task<Person?> GetByIdAsync(int id)
		{
			return await _context.Persons.FindAsync(id);
		}
	}
}
