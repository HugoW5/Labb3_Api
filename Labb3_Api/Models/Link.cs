using System.ComponentModel.DataAnnotations;

namespace Labb3_Api.Models
{
	public class Link
	{
		public int Id { get; set; }
		[Required]
		[Url]
		public string Url { get; set; } = null!;
		public Person Person { get; set; } = null!;
		public Interest Interest { get; set; } = null!;
	}
}
