using Labb3_Api.DTOs;
using Labb3_Api.Models;

namespace Labb3_Api.Repositories.Interfaces
{
	public interface ILinkRepository
	{
		public Task<Link> AddLink(Link link);
	}
}
