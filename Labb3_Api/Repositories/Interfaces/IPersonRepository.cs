using Labb3_Api.DTOs;
using Labb3_Api.Models;
namespace Labb3_Api.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		public Task<IEnumerable<Person>> GetAllAsync();
		public Task<Person?> GetByIdAsync(int id);
		public Task<IEnumerable<Link?>> GetAllLinksAsync(int id);
		public Task<IEnumerable<Interest>> GetAllInterestsAsync(int id);
		public Task<Person?> AddInterest(Person person, Interest interest);
		public Task<Person> CreateNewPerson(Person person);
	}
}
