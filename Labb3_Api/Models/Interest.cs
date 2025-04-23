using System.ComponentModel.DataAnnotations;

namespace Labb3_Api.Models
{
	public class Interest
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = null!;
		[MaxLength(255)]
		public string Description { get; set; } = null!;

		public ICollection<Link> Links { get; set; } = new List<Link>();
		public ICollection<Person> People { get; set; } = new List<Person>();
	}
}
