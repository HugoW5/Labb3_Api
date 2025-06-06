﻿namespace Labb3_Api.DTOs
{
	public record PersonDTO
	{
		public int Id { get; init; }
		public string FirstName { get; init; } = null!;
		public string LastName { get; init; } = null!;
		public string Email { get; init; } = null!;
		public string PhoneNumber { get; init; } = null!;
		public ICollection<InterestDTO> Interests { get; init; } = new List<InterestDTO>();
		public ICollection<LinkDTO> Links { get; init; } = new List<LinkDTO>();
	}
}
