using Labb3_Api.DTOs;
using Labb3_Api.Models;
namespace Labb3_Api.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		public Task<IEnumerable<Person>> GetAllAsync();
		public Task<PersonDTO?> GetByIdAsync(int id);
		public Task<IEnumerable<LinkDTO>> GetAllLinksAsync(int id);
		public Task<Person?> AddInterest(int personId, int interestId);
	}
}
