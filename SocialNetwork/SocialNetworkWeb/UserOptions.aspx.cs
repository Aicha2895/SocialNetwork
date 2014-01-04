using System;
using SocialNetwork.Entities;
using SocialNetwork.Services;

namespace SocialNetworkWeb
{
	public partial class UserOptions : System.Web.UI.Page
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

		protected void Button_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				var user = new UserEntity()
					{
						Id = ContextManager.GetUserIdFromContext(this.Context),
						Name = NameTextBox.Text,
						Surname = SurnameTextBox.Text,
						Activities = ActivitiesTextBox.Text,
						Description = DescriptionTextBox.Text,
						PhoneNumbers = PhonesTextBox.Text
					};

				DateTime dateOfBirth = new DateTime();

				if (DateTime.TryParse(DateOfBirthTextBox.Text, out dateOfBirth))
				{
					user.DateOfBirth = dateOfBirth;
				}
				else
				{
					user.DateOfBirth = null;
				}


				_userService.UpdateUser(user);

				ChangesSavedLabel.Visible = true;
				ChangesSavedLabel.Text = string.Format("Изменения сохранены {0}", DateTime.Now.ToString("R"));
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			var user = _userService.GetUserById(ContextManager.GetUserIdFromContext(this.Context));

			NameTextBox.Text = user.Name;
			SurnameTextBox.Text = user.Surname;
			ActivitiesTextBox.Text = user.Activities;
			PhonesTextBox.Text = user.PhoneNumbers;
			DescriptionTextBox.Text = user.Description;
			DateOfBirthLabel.Text = user.DateOfBirth == null ? string.Empty : ((DateTime)user.DateOfBirth).ToShortDateString();
		}
	}
}