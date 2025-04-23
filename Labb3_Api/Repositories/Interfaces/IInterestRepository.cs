using Labb3_Api.DTOs;
using Labb3_Api.Models;
namespace Labb3_Api.Repositories.Interfaces
{
	public interface IInterestRepository
	{
		public Task<IEnumerable<Interest>> GetAllAsync();
		public Task<Interest?> AddInterest(InterestDTO interest);
		public Task<IEnumerable<LinkDTO>> GetAllLinksAsync(int id);

	}
}
