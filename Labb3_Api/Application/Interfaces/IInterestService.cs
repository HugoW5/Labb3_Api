using Labb3_Api.DTOs;
using Labb3_Api.Models;

namespace Labb3_Api.Application.Interfaces
{
	public interface IInterestService
	{
		public Task<IEnumerable<InterestDTO>> GetAllInterestsAsync();
		public Task<InterestDTO?> GetInterestByIdAsync(int id);
		public Task<Interest?> AddInterestAsync(CreateNewInterest interest);

	}
}
