using System;

namespace SocialNetwork.Entities
{
	public class UserEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
		public string Surname { get; set; }
		
		public string Activities { get; set; }
		
		public string Description { get; set; }
		
		public DateTime? DateOfBirth { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string PhoneNumbers { get; set; }
	}
}