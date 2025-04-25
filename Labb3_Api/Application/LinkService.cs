using Labb3_Api.Application.Interfaces;
using Labb3_Api.DTOs;
using Labb3_Api.Models;
using Labb3_Api.Repositories.Interfaces;

namespace Labb3_Api.Application
{
	public class LinkService : ILinkService
	{
		private readonly ILinkRepository _linkRepository;
		private readonly IInterestRepository _interestRepository;
		private readonly IPersonRepository _personRepository;
		public LinkService(ILinkRepository linkRepository, IInterestRepository interestRepository, IPersonRepository personRepository)
		{
			_linkRepository = linkRepository;
			_interestRepository = interestRepository;
			_personRepository = personRepository;
		}

		public async Task<LinkDTO?> AddNewLink(AddNewLinkRequest link)
		{
			if (link == null || link.Url == string.Empty)
			{
				return null;
			}
			var person = await _personRepository.GetByIdAsync(link.PersonId);
			var interest = await _interestRepository.GetInterestById(link.InterestId);
			if (person == null)
			{
				return null;
			}
			if (interest == null)
			{
				return null;
			}
			var newLink = new Link
			{
				Url = link.Url,
				Person = person,
				Interest = interest
			};
			var createdLink = await _linkRepository.AddLink(newLink);
			return new LinkDTO { Url = createdLink.Url };
		}
	}
}
