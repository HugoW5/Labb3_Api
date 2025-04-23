namespace Labb3_Api.DTOs
{
	public class PersonDTO
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public ICollection<InterestDTO> Interests { get; set; } = new List<InterestDTO>();
		public ICollection<LinkDTO> Links { get; set; } = new List<LinkDTO>();
	}
}
