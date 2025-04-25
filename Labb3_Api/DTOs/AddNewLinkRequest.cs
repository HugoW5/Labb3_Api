namespace Labb3_Api.DTOs
{
	public record AddNewLinkRequest
	{
		public string Url { get; init; } = null!;
		public int InterestId { get; init; }
		public int PersonId { get; init; }
	}
}
