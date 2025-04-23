using System.ComponentModel.DataAnnotations;

namespace Labb3_Api.DTOs
{
	public class InterestDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
