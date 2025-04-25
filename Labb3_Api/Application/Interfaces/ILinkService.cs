using Labb3_Api.DTOs;
using Labb3_Api.Models;

namespace Labb3_Api.Application.Interfaces
{
	public interface ILinkService
	{
		public Task<LinkDTO?> AddNewLink(AddNewLinkRequest link);
	}
}
