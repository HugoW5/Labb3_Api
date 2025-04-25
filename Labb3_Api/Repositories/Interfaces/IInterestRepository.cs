using Labb3_Api.DTOs;
using Labb3_Api.Models;
namespace Labb3_Api.Repositories.Interfaces
{
	public interface IInterestRepository
	{
		public Task<IEnumerable<Interest>> GetAllAsync();
		public Task<Interest?> AddInterest(Interest interest);
		public Task<Interest?> GetInterestById(int id);
		public Task<IEnumerable<Link>> GetAllLinksAsync(int id);

	}
}
