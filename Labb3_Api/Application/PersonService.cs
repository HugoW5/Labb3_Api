using Labb3_Api.Application.Interfaces;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;

namespace Labb3_Api.Application
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepository;
		private readonly IInterestRepository _interestRepository;
		public PersonService(IPersonRepository personRepository, IInterestRepository interestRepository)
		{
			_personRepository = personRepository;
			_interestRepository = interestRepository;
		}
		public async Task<Person?> AddInterestAsync(int personId, int interestId)
		{
			var person = await _personRepository.GetByIdAsync(personId);
			var interest = await _interestRepository.GetInterestById(interestId);
			if (person == null)
			{
				return null;
			}
			if (interest == null)
			{
				return null;
			}
			return await _personRepository.AddInterest(person, interest);
		}


		public async Task<IEnumerable<LinkDTO?>> GetAllLinksAsync(int personId)
		{
			var links = await _personRepository.GetAllLinksAsync(personId);
			var linksDTO = links.Select(l => new LinkDTO
			{
				Url = l!.Url
			}).ToList();
			return linksDTO;

		}

		public async Task<IEnumerable<Person>> GetAllAsync()
		{
			return await _personRepository.GetAllAsync();
		}

		public async Task<PersonDTO?> GetPersonByIdAsync(int id)
		{
			var person = await _personRepository.GetByIdAsync(id);
			var links = await _personRepository.GetAllLinksAsync(id);
			var interests = await _personRepository.GetAllInterestsAsync(id);

			var InterestsDTO = interests.Select(i => new InterestDTO
			{
				Id = i.Id,
				Title = i.Title,
				Description = i.Description
			}).ToList();
			var linksDTO = links.Select(l => new LinkDTO
			{
				Url = l!.Url
			}).ToList();

			return (new PersonDTO
			{
				Id = id,
				FirstName = person!.FirstName,
				LastName = person.LastName,
				Email = person.Email,
				PhoneNumber = person.PhoneNumber,
				Interests = InterestsDTO,
				Links = linksDTO
			});
		}

		public async Task<IEnumerable<Person>> GetAllPersonsAsync()
		{
			return await _personRepository.GetAllAsync();
		}

		public async Task<Person?> CreateNewPersonAsync(CreatePersonDTO person)
		{
			var newPerson = new Person
			{
				FirstName = person.FirstName,
				LastName = person.LastName,
				Email = person.Email,
				PhoneNumber = person.PhoneNumber,
			};
			var createdPerson = await _personRepository.CreateNewPerson(newPerson);
			return createdPerson;
		}
	}
}
