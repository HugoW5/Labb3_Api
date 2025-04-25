using Labb3_Api.Application.Interfaces;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories;
using Labb3_Api.Repositories.Interfaces;
namespace Labb3_Api.Application
{
	public class InterestService : IInterestService
	{
		private readonly IInterestRepository _interestRepository;
		public InterestService(IInterestRepository interestRepository)
		{
			_interestRepository = interestRepository;
		}
		public async Task<Interest?> AddInterestAsync(CreateNewInterest interestDTO)
		{
			var Interest = new Interest
			{
				Title = interestDTO.Title,
				Description = interestDTO.Description,
				Links = new List<Link>(),
			};
			var newInterest = await _interestRepository.AddInterest(Interest);
			return newInterest;

		}

		public async Task<IEnumerable<InterestDTO>> GetAllInterestsAsync()
		{
			var interests = await _interestRepository.GetAllAsync();
			var interestsDTOs = interests.Select(i => new InterestDTO
			{
				Id = i.Id,
				Title = i.Title,
				Description = i.Description
			}).ToList();

			return interestsDTOs;
		}

		public Task<InterestDTO?> GetInterestByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
