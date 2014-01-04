using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Entities;
using SocialNetworkDataAccess;

namespace SocialNetwork.Services
{
	public class ContentService
	{
		private DataBaseEntities _context;

		public ContentService()
		{
			_context = new DataBaseEntities();
		}

		public void AddPost(PostEntity post)
		{
			int postId = 0;
			
			if (_context.Posts.Count() > 0)
			{
				postId = _context.Posts.Max(p => p.Id);
			}


			var dbPost = new Post()
				{
					Id = ++postId,
					FkUserId = post.FeedUserId,
					FkFromUserId = post.FromUserId,
					PostText = post.Text,
					CreatedDate = post.CreatedDate
				};

			_context.Posts.AddObject(dbPost);
			_context.SaveChanges();
		}

		public List<PostEntity> GetPostsForUser(int userId)
		{
			var resultList = new List<PostEntity>();

			var userFeedPosts = _context.Posts.Where(p => p.FkUserId == userId);
			if (userFeedPosts.Any())
			{
				resultList = userFeedPosts
			        .OrderByDescending(p => p.CreatedDate)
			        .Take(10)
			        .Select( p => new PostEntity() 
						{
							Id = p.Id,
							FeedUserId = p.FkUserId,
							FromUserId = p.FkFromUserId,
							FromUserName = p.FromUser.Name,
							CreatedDate = p.CreatedDate,
							Text = p.PostText
					})
			        .ToList();
			}

			return resultList;
		}
	}
}