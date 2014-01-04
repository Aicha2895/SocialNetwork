using System;
using System.Web;
using System.Web.UI.WebControls;
using SocialNetwork.Services;

namespace SocialNetworkWeb
{
	public partial class Register : System.Web.UI.Page
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

		protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = _userService.IsEmailUnique(EmailTextBox.Text);
		}

		protected void RegisterButton_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				int userId = _userService.Register(
					EmailTextBox.Text,
					PasswordTextBox.Text,
					NameTextBox.Text,
					SurnameTextBox.Text
					);

				var myCookie = new HttpCookie("UserId");
				myCookie.Value = userId.ToString();
				myCookie.Expires = DateTime.Now.AddDays(30);
				Response.Cookies.Add(myCookie);

				Response.Redirect("~/UserOptions.aspx");
			}
		}
	}
}