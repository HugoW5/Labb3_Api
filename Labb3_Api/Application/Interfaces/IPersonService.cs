using Labb3_Api.DTOs;
using Labb3_Api.Models;

namespace Labb3_Api.Application.Interfaces
{
	public interface IPersonService
	{
		Task<PersonDTO?> AddInterestAsync(int personId, int interestId);
		Task<IEnumerable<Person>> GetAllPersonsAsync();
		Task<IEnumerable<LinkDTO?>> GetAllLinksAsync(int personId);
		Task<PersonDTO?> GetPersonByIdAsync(int id);
		Task<Person?> CreateNewPersonAsync(CreatePersonDTO person);
		Task<IEnumerable<InterestDTO?>> GetAllInterestsAsync(int personId);
	}

}
