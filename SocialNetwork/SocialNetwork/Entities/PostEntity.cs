using System;

namespace SocialNetwork.Entities
{
	public class PostEntity
	{
		public int Id { get; set; }

		public DateTime CreatedDate { get; set; }

		public string Text { get; set; }

		public int FromUserId { get; set; }

		public string FromUserName { get; set; }

		public int FeedUserId { get; set; }
	}
}