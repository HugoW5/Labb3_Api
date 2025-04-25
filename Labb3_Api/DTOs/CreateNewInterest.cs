namespace Labb3_Api.DTOs
{
	public record CreateNewInterest
	{
		public string Title { get; init; } = null!;
		public string Description { get; init; } = null!;
	}
}
