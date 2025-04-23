using System.ComponentModel.DataAnnotations;

namespace Labb3_Api.Models
{
	public class Person
	{
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		[EmailAddress]
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;

		public ICollection<Interest> Interests { get; set; } = new List<Interest>();
		public ICollection<Link> Links { get; set; } = new List<Link>();
	}
}
