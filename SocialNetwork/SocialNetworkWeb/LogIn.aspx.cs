using System;
using System.Web;
using SocialNetwork.Entities;
using SocialNetwork.Services;

namespace SocialNetworkWeb
{
	public partial class LogIn : System.Web.UI.Page
	{
		private UserService _userService;

		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);
			_userService = new UserService();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void GoButton_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				UserEntity user = _userService.Authentificate(EmailTextBox.Text, PasswordTextBox.Text);

				if (user.Id == 0)
				{
					NoUserLabel.Visible = true;
				}
				else
				{
					var myCookie = new HttpCookie("UserId");
					myCookie.Value = user.Id.ToString();
					myCookie.Expires = DateTime.Now.AddDays(30);
					Response.Cookies.Add(myCookie);

					Response.Redirect("~/ViewProfile.aspx");
				}
			}
		}
	}
}