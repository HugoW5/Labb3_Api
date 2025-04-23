namespace Labb3_Api.DTOs
{
	public record CreatePersonDTO
	{
		public string FirstName { get; init; } = null!;
		public string LastName { get; init; } = null!;
		public string Email { get; init; } = null!;
		public string PhoneNumber { get; init; } = null!;
	}
}
