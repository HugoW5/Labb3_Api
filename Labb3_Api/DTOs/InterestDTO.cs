using System.ComponentModel.DataAnnotations;

namespace Labb3_Api.DTOs
{
	public record InterestDTO
	{
		public int Id { get; init; }
		public string Title { get; init; } = null!;
		public string Description { get; init; } = null!;
	}
}
