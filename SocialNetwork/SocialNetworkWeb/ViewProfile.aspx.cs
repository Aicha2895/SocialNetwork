using System;
using SocialNetwork.Entities;
using SocialNetwork.Services;

namespace SocialNetworkWeb
{
	public partial class ViewProfile : System.Web.UI.Page
	{
		private UserService _userService;
		private ContentService _contentService;
		private int _currentUserId;

		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);
			_userService = new UserService();
			_contentService = new ContentService();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			_currentUserId = ContextManager.GetUserIdFromContext(this.Context);
		}

		protected void AddPostButton_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				int postToUserId = 0;
				if (Int32.TryParse(FeedUserId.Value, out postToUserId))
				{
					var post = new PostEntity()
						{
							FeedUserId = postToUserId,
							FromUserId = _currentUserId,
							Text = NewPostTextBox.Text,
							CreatedDate = DateTime.Now
						};

					_contentService.AddPost(post);
				}

				NewPostTextBox.Text = string.Empty;
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			
			int userId = 0;

			if (Request.Params["id"] == null)
			{
				userId = _currentUserId;
			}
			else
			{
				Int32.TryParse(Request.Params["id"], out userId);
			}

			FeedUserId.Value = userId.ToString();
			UserEntity viewedUser = _userService.GetUserById(userId);

			FillUserInfo(viewedUser);

			FillUserField(viewedUser);
		}

		private void FillUserField(UserEntity viewedUser)
		{
			FeedPostsRepeated.DataSource = _contentService.GetPostsForUser(viewedUser.Id);
			FeedPostsRepeated.DataBind();
		}

		private void FillUserInfo(UserEntity currentUser)
		{
			NameLabel.Text = currentUser.Name;
			SurnameLabel.Text = currentUser.Surname;
			DescriptionLabel.Text = currentUser.Description == null ? string.Empty : currentUser.Description.Replace(Environment.NewLine, "<br/>");
			ActivitiesLabel.Text = currentUser.Activities == null ? string.Empty : currentUser.Activities.Replace(Environment.NewLine, "<br/>");
			BirthDayLabel.Text = currentUser.DateOfBirth == null
				                     ? string.Empty
				                     : ((DateTime) currentUser.DateOfBirth).ToString("dd MMMM yyyy");
			PhonesLabel.Text = currentUser.PhoneNumbers;
		}
	}
}